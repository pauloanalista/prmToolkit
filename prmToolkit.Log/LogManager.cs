using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using prmToolkit.Log.Enum;
using prmToolkit.Log.Helpers;
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
        private static string _dataArquivo = string.Empty;
        static string filePath;
        static string applicationName;
        private static FileLog _fileLog;

        #region Métodos Públicos
        public static void Save(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;


            string enumModeToSave = ConfigHelper.GetKeyAppSettings("Log_ModeToSave");


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


        #endregion

        #region Métodos Privados

        private static void SaveToContigency(string message)
        {
            string whereToSave = ConfigHelper.GetKeyAppSettings("Log_WhereToSave");

            string[] vetEnumLogType = whereToSave.Split(',');

            int contingencyNumberUsed = 0;
            int contingencyNumberUsedWithError = 0;

            foreach (var enumLogType in vetEnumLogType)
            {
                ILog log = FactoryLog.GetLogType(enumLogType);

                contingencyNumberUsed++;

                try
                {

                    log.Save(message);

                    break;

                }
                catch 
                {
                    
                    contingencyNumberUsedWithError++;
                }
            }

            if (contingencyNumberUsed == contingencyNumberUsedWithError)
            {
                throw new Exception("Não foi possível salvar o log.");
            }
        }

        private static void SaveToAll(string message)
        {
            string whereToSave = ConfigHelper.GetKeyAppSettings("Log_WhereToSave");

            whereToSave.Trim().Split(',').ToList().ForEach(enumLogType =>
            {
                ILog log = FactoryLog.GetLogType(enumLogType);
                
                _fileLog.Save(message);

            });
        }

        #endregion

    }
}
