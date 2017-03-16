using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prmToolkit.Validation
{
    public class ArgumentsValidator
    {
        #region Constructor
        protected ArgumentsValidator()
        {
        }
        #endregion

        /// <summary>
        /// Método responsável por levantar uma exceção que contém uma única mensagem que representa o conjunto de validações realizada.
        /// </summary>
        /// <param name="mensagem">Será levantada uma exceção com uma única mensagem, caso queira exibir todas as mensagens não utilize essa sobrecarga</param>
        /// <param name="validations">Lista de validações a serem realizadas</param>
        /// <returns>Levanta uma exceção com uma única mensagem.</returns>
        public static void RaiseExceptionOfInvalidArguments(string mensagem, params Exception[] validations)
        {
            var exceptionCollection = validations.ToList().Where(validation => validation != null).ToList();

            if (exceptionCollection.Count == 0)
            {
                return;
            }

            //Subistitui todas exceções por uma única exceção
            List<Exception> exList = new List<Exception>();
            exList.Add(new Exception(mensagem));

            string messageList = JsonConvert.SerializeObject(new { Mensagens = exList.Select(x => x.Message).ToList() });

            throw new Exception(messageList);

        }


        /// <summary>
        /// Método responsável por levantar uma exceção que contém uma lista de mensagens de acordo com o conjunto de validações realizada.
        /// </summary>
        /// <param name="validations">Lista de validações a serem realizadas</param>
        /// <returns>Levanta uma exceção com mensagens agrupadas.</returns>
        public static void RaiseExceptionOfInvalidArguments(params Exception[] validations)
        {
            var exceptionCollection = validations.ToList().Where(validation => validation != null).ToList();

            if (exceptionCollection.Count == 0)
            {
                return;
            }

            string messageList = JsonConvert.SerializeObject(new { Mensagens = exceptionCollection.Select(x => x.Message).ToList() });

            throw new Exception(messageList);

        }

        /// <summary>
        /// Baseado em uma lista de validações ele retorna a lista de erros sem levantar a exceção
        /// </summary>
        /// <param name="validations">Lista de validações a serem realizadas</param>
        /// <returns>Retorna a lista de erros causada pelas validações</returns>
        public static List<Exception> GetExceptionList(params Exception[] validations)
        {
            var exceptionCollection = validations.ToList().Where(validation => validation != null).ToList();

            return exceptionCollection;
        }

        /// <summary>
        /// Baseado em uma lista de validações ele retorna a lista de mensagens de erros sem levantar a exceção
        /// </summary>
        /// <param name="validations">Lista de validações a serem realizadas</param>
        /// <returns>Retorna a lista de mensagens de erros causada pelas validações</returns>
        public static List<string> GetMessagesFromExceptions(params Exception[] validations)
        {
            var messageList = validations.ToList().Where(validation => validation != null).Select(x => x.Message).ToList();

            return messageList;
        }

    }
}