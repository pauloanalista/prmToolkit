using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using prmToolkit.Validation;

namespace prmToolkit.Test
{
    [TestClass]
    public class ValidationTest
    {
        /// <summary>
        /// Este método captura as mensagens das exceções lançadas pelos argumentos 
        /// mas não é lançada uma exceção para o usuário
        /// </summary>
        [TestMethod]
        public void ObterListaDeMensagensDasExcecoes()
        {
            List<string> result = ArgumentsValidator.GetMessagesFromExceptions(
                                    RaiseException.IfNull(null, "object is required"),
                                    RaiseException.IfNotEmail("email_invalid", "email invalid")
                );

            Assert.IsNotNull(result, "object required");
            Assert.IsTrue(result.Count == 2, "There should be two exceptions");
        }
        /// <summary>
        /// Este método captura as exceções lançadas pelos os argumentos 
        /// mas não é lançada uma exceção para o usuário
        /// </summary>
        [TestMethod]
        public void ObterListaDeExecoesSemLancar()
        {
            List<Exception> result = ArgumentsValidator.GetExceptionList(
                                    RaiseException.IfNull(null, "object is required"),
                                    RaiseException.IfNotEmail("email_invalid", "email invalid")
                );

            Assert.IsNotNull(result, "object required");
            Assert.IsTrue(result.Count == 2, "There should be two exceptions");
        }

        /// <summary>
        /// Este método lança uma única exceção, com as mensagens das exceções geradas pelos os argumentos 
        /// </summary>
        [TestMethod]
        public void LancarUnicaExcecaoComMensagensDoGrupoDeExcecoes()
        {
            try
            {
                ArgumentsValidator.RaiseExceptionOfInvalidArguments(
                                            RaiseException.IfNull(null, "object is required"),
                                            RaiseException.IfNotEmail("email_invalid", "email invalid")
                                            );


            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex.Message.Contains("object is required") && ex.Message.Contains("email invalid"), "There should be two exceptions");
            }
        }

        /// <summary>
        /// Este método lança uma única exceção, com uma única mensagem que represanta as exceções geradas pelos os argumentos 
        /// </summary>
        [TestMethod]
        public void LancarUnicaExcecaoComUnicaMensagemDoGrupoDeExcecoes()
        {
            try
            {
                bool existe = true;

                ArgumentsValidator.RaiseExceptionOfInvalidArguments("Dados inválidos",
                                            RaiseException.IfTrue(existe),
                                            RaiseException.IfNotEmail("paulo.com.br")
                                            );

            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex.Message.Contains("Dados inválidos"), "There should be two exceptions");
            }
        }

        /// <summary>
        /// Este método lança uma exceção indivídual para o usuário
        /// </summary>
        [TestMethod]
        public void LancarExcecaoIndividual()
        {
            try
            {
                RaiseException.IfNotNull(null, "object is required", true);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "object is required", "is expected value not null");
            }
        }


        /// <summary>
        /// Testando se uma coleção é vazia
        /// </summary>
        [TestMethod]
        public void LancarExcecaoIndividualCasoAsColecoesNaoTenhamItemDentro()
        {
            string mensagem = "Não há itens na coleção";
            List<string> lista = new List<string>();
            int[] numeros = new int[] { };
            string[] nomes = new string[] { };

            try
            {

                List<string> mgs = ArgumentsValidator.GetMessagesFromExceptions(
                RaiseException.IfCollectionEmpty(lista, mensagem),
                RaiseException.IfCollectionEmpty(numeros, mensagem),
                RaiseException.IfCollectionEmpty(nomes, mensagem));

                Assert.IsTrue(mgs.Count == 3, "As coleções estao nulas.");
            }
            catch (Exception ex)
            {

                throw ex;
            }

            

        }
    }
}
