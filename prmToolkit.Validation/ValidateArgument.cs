using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prmToolkit.Validation
{
    public class ValidateArgument
    {
        #region Constructor
        protected ValidateArgument()
        {
        }
        #endregion

        /// <summary>
        /// Método responsável por levantar uma lista de exceções, caso todos os parametros estejam ok, ele deixa seguir para linha seguinte do código.
        /// </summary>
        /// <param name="returnManyExceptions">True - Retorna várias exceções agrupadas, ou seja, cada exceção tem sua mensagem. False - Retorna uma única exceção com todas as mensagens agrupadas no formato JSON.</param>
        /// <param name="validations">Lista de validações a serem realizadas</param>
        /// <returns>Levanta uma exceção com mensagens agrupadas ou um grupo de exceções com cada uma com sua mensagem.</returns>
        public static void IsOkContinue(bool returnManyExceptions, params Exception[] validations)
        {
            var exceptionCollection = validations.ToList().Where(validation => validation != null).ToList();

            if (exceptionCollection.Count == 0)
            {
                return;
            }

            if (returnManyExceptions == true)
            {
                throw new AggregateException(exceptionCollection);
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