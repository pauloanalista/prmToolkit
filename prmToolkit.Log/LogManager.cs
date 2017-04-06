using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using prmToolkit.Log.Enum;
using prmToolkit.Log.Interfaces;
using prmToolkit.Validation;
using System;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace prmToolkit.Log
{
    public static class LogManager
    {
        public static void Save(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;


            string enumModeToSave = GetKeyAppSettings("Log_ModeToSave");


            if (int.Parse(enumModeToSave) == (int)EnumModeToSave.SaveToAll)
            {
                //Salva em todos os lugares configurados
                SaveToAll(message);
            }
            else if (int.Parse(enumModeToSave) == (int)EnumModeToSave.SaveToContigency)
            {
                //Salva no primeiro local configurado, caso de algum erro, salva no próximo lugar
                SaveToContigency(message);
            }
        }

        private static void SaveToContigency(string message)
        {
            string whereToSave = GetKeyAppSettings("Log_WhereToSave");

            string[] vetEnumLogType = whereToSave.Split(',');

            int contingencyNumberUsed = 0;
            int contingencyNumberUsedWithError = 0;

            vetEnumLogType.ToList().ForEach(enumLogType =>
                {
                    ILog log = null;

                    if (int.Parse(enumLogType) == (int)EnumLogType.SaveToFile)
                    {
                        contingencyNumberUsed++;

                        try
                        {
                            string filePath = GetKeyAppSettings("Log_FilePath");
                            string applicationName = GetKeyAppSettings("Log_ApplicationName");

                            log = new FileLog(filePath, applicationName);
                            log.Save(message);

                        }
                        catch
                        {
                            contingencyNumberUsedWithError++;
                        }
                    }
                    else if (int.Parse(enumLogType) == (int)EnumLogType.SaveToDatabase)
                    {
                        contingencyNumberUsed++;

                        try
                        {
                            string applicationName = GetKeyAppSettings("Log_ApplicationName");
                            log = new DatabaseLog(applicationName, GetConnectionString(), AccessMultipleDatabaseWithAdoNet.Enumerators.EnumDatabaseType.MySql);
                            log.Save(message);
                        }
                        catch
                        {
                            contingencyNumberUsedWithError++;
                        }
                    }
                    else if (int.Parse(enumLogType) == (int)EnumLogType.SaveToEventViewer)
                    {
                        contingencyNumberUsed++;

                        try
                        {
                            string sourceEventViewer = GetKeyAppSettings("Log_SourceEventViewer");

                            log = new EventViewerLog(sourceEventViewer);
                            log.Save(message);
                        }
                        catch
                        {
                            contingencyNumberUsedWithError++;
                        }
                    }
                });

            if (contingencyNumberUsed == contingencyNumberUsedWithError)
            {
                throw new Exception("Não foi possível salvar o log.");
            }


        }

        private static void SaveToAll(string message)
        {
            string whereToSave = GetKeyAppSettings("Log_WhereToSave");

            whereToSave.Trim().Split(',').ToList().ForEach(enumLogType =>
            {
                //Thread t = new Thread(() =>
                //{
                ILog log = null;
                if (int.Parse(enumLogType) == (int)EnumLogType.SaveToFile)
                {
                    string filePath = GetKeyAppSettings("Log_FolderPath");
                    string applicationName = GetKeyAppSettings("Log_ApplicationName");
                    log = new FileLog(filePath, applicationName);
                }
                else if (int.Parse(enumLogType) == (int)EnumLogType.SaveToDatabase)
                {
                    string applicationName = GetKeyAppSettings("Log_ApplicationName");
                    log = new DatabaseLog(applicationName, GetConnectionString(), EnumDatabaseType.MySql);
                }
                else if (int.Parse(enumLogType) == (int)EnumLogType.SaveToEventViewer)
                {
                    string sourceEventViewer = GetKeyAppSettings("Log_SourceEventViewer");

                    log = new EventViewerLog(sourceEventViewer);
                }

                log.Save(message);
                //});
            });
        }



        private static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Log_ConnectionString"]?.ConnectionString;

            RaiseException.IfNullOrEmpty(connectionString, "Chave 'Log_ConnectionString' não definida no CONNECTIONSTRINGS. Verifique seu WebConfig ou AppConfig.", true);

            return connectionString;
        }



        public static string GetKeyAppSettings(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            RaiseException.IfNullOrEmpty(value, $"Chave '{key}' não definida no APPSETTINGS. Verifique seu WebConfig ou AppConfig.", true);

            return value;
        }
    }
}
