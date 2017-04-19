using prmToolkit.Validation;
using System.Configuration;

namespace prmToolkit.Log.Infra.Helpers
{
    public static class ConfigHelper
    {
        public static string GetKeyAppSettings(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            RaiseException.IfNullOrEmpty(value, $"Chave '{key}' não definida no APPSETTINGS. Verifique seu WebConfig ou AppConfig.", true);

            return value;
        }

        public static string GetConnectionString(string key)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[key]?.ConnectionString;

            RaiseException.IfNullOrEmpty(connectionString, "Chave 'Log_ConnectionString' não definida no CONNECTIONSTRINGS. Verifique seu WebConfig ou AppConfig.", true);

            return connectionString;
        }
    }
}
