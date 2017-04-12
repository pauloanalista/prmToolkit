using prmToolkit.Log.Enum;
using prmToolkit.Log.Helpers;
using prmToolkit.Log.Interfaces;

namespace prmToolkit.Log
{
    public static class FactoryLog
    {
        static string filePath;
        static string applicationName;
        private static FileLog _fileLog;


        public static ILog GetLogType(string enumLogType)
        {
            ILog log = null;
            switch (int.Parse(enumLogType))
            {
                case (int)EnumLogType.SaveToDatabase:
                    {

                        string applicationName = ConfigHelper.GetKeyAppSettings("Log_ApplicationName");
                        log = new DatabaseLog(applicationName, ConfigHelper.GetConnectionString(), AccessMultipleDatabaseWithAdoNet.Enumerators.EnumDatabaseType.MySql);
                    }
                    break;

                case (int)EnumLogType.SaveToFile:
                    {
                        if (string.IsNullOrEmpty(filePath))
                        {
                            filePath = ConfigHelper.GetKeyAppSettings("Log_FolderPath");
                            applicationName = ConfigHelper.GetKeyAppSettings("Log_ApplicationName");
                        }

                        log = new FileLog(filePath, applicationName);
                    }
                    break;

                case (int)EnumLogType.SaveToEventViewer:
                    {
                        string sourceEventViewer = ConfigHelper.GetKeyAppSettings("Log_SourceEventViewer");

                        log = new EventViewerLog(sourceEventViewer);

                    }
                    break;

                default: return null;
            }

            return log;

        }

       
    }
}
