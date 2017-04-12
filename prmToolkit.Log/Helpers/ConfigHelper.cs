using prmToolkit.Validation;
using System.Collections.Generic;
using System.Configuration;

namespace prmToolkit.Log.Helpers
{
    public static class ConfigHelper
    {
        public static string GetKeyAppSettings(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            RaiseException.IfNullOrEmpty(value, $"Chave '{key}' não definida no APPSETTINGS. Verifique seu WebConfig ou AppConfig.", true);

            return value;
        }

        public static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Log_ConnectionString"]?.ConnectionString;

            RaiseException.IfNullOrEmpty(connectionString, "Chave 'Log_ConnectionString' não definida no CONNECTIONSTRINGS. Verifique seu WebConfig ou AppConfig.", true);

            return connectionString;
        }
    }
}
