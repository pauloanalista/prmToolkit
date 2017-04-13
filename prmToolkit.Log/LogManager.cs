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
        #region Métodos Públicos
        public static void Save(string message, EnumMessageType enumMessageType = EnumMessageType.Information)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            
            //Verifica se tem permissão para gravar o tipo de mensagem
            if (HasPermissionSaveMessageType(enumMessageType) == false) return;

            try
            {
                //Salva em todos os lugares configurados
                SaveToAll(message, enumMessageType);
            }
            catch (Exception ex)
            {
                //Verifica se tem permissão para gravar o tipo de mensagem
                if (HasPermissionSaveMessageType(enumMessageType) == false) return;

                //Salva no primeiro local configurado, caso de algum erro, salva no próximo lugar
                SaveToContigency("LOG_SAVEALL -> " + GetMessageOfException(ex), EnumMessageType.Error);
                SaveToContigency("LOG_CONTIGENCY -> " + message);
            }
        }

      
        public static void Save(Exception exception)
        {
            Save(GetMessageOfException(exception));
        }
        #endregion

        #region Métodos Privados

        private static bool HasPermissionSaveMessageType(EnumMessageType enumMessageType)
        {
            
            string enumsMessageType = ConfigHelper.GetKeyAppSettings("Log_MessageType_View");
            string[] vetEnumsMessageType = enumsMessageType.Trim().Split(',');

            //Verifica se o tipo de messagem tem permissao para gravar
            bool permissao = false;
            vetEnumsMessageType.ToList().ForEach(x => {
                if (int.Parse(x) == (int)enumMessageType)
                {
                    permissao = true;
                }
            });

            return permissao;
        }


        private static string GetMessageOfException(Exception exception)
        {
            string data = DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss");
            string mensagem = string.Empty;

            EnumExceptionDetail enumExceptionDetail = (EnumExceptionDetail)int.Parse(ConfigHelper.GetKeyAppSettings("Log_Detail_Set_EnumExceptionDetail"));

            if (enumExceptionDetail == EnumExceptionDetail.Simple)
            {
                mensagem = $"{ data} SIMPLE - > {exception.Message}";
            }
            else if (enumExceptionDetail == EnumExceptionDetail.Synthetic)
            {
                mensagem = $"{ data} SYNTHETIC - > {exception.Message} - {exception.StackTrace} > {exception.InnerException?.Message} - {exception.InnerException?.StackTrace}";
            }
            else if (enumExceptionDetail == EnumExceptionDetail.Analytical)
            {
                mensagem = $"{ data} ANALYTICAL - > {exception.ToString()}";
            }

            return mensagem;
        }

        private static void SaveToContigency(string message, EnumMessageType enumMessageType = EnumMessageType.Information)
        {
            string whereToSave = ConfigHelper.GetKeyAppSettings("Log_TrySave_Set_Sequence_EnumLogType_Contingency");

            string[] vetEnumLogType = whereToSave.Split(',');

            int contingencyNumberUsed = 0;
            int contingencyNumberUsedWithError = 0;

            foreach (var enumLogType in vetEnumLogType)
            {
                ILog log = FactoryLog.GetLogType(enumLogType);

                contingencyNumberUsed++;

                try
                {
                    log.Save(message, enumMessageType);

                    break;
                }
                catch
                {
                    contingencyNumberUsedWithError++;
                }
            }

            if (contingencyNumberUsed == contingencyNumberUsedWithError)
            {
                throw new Exception("LOG_CONTIGENCY -> Não foi possível salvar o log.");
            }
        }

        private static void SaveToAll(string message, EnumMessageType enumMessageType)
        {
            string whereToSave = ConfigHelper.GetKeyAppSettings("Log_SaveAll_Set_Sequence_EnumLogType");

            whereToSave.Trim().Split(',').ToList().ForEach(enumLogType =>
            {
                ILog log = FactoryLog.GetLogType(enumLogType);

                log.Save(message, enumMessageType);

            });
        }

        #endregion

    }
}
