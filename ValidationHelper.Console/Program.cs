using prmToolkit.Validation;
using System;
using System.Collections.Generic;

namespace ValidationHelper.Console
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                List<Exception> exceptionCollection = ObterListaDeException();

                LevantarMaisDeUmaExcecao();
            }
            catch (Exception ex)
            {

            }
        }

        public static void LevantarMaisDeUmaExcecao()
        {
            ValidateArgument.IsOkContinue(
                            ValidateArgument.IsNotNull(null, "Nome não pode ser nulo"),
                            ValidateArgument.IsEmail("xxxx", "É necessário passar um email valido")
                );
        }

        public static List<Exception> ObterListaDeException()
        {
            return ValidateArgument.GetListException(
                            ValidateArgument.IsNotNull(null, "Nome não pode ser nulo"),
                            ValidateArgument.IsEmail("xxxx", "É necessário passar um email valido")
                );
        }



    }
}
