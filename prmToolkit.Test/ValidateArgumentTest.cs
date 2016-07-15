using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prmToolkit.Validation;

namespace prmToolkit.Test
{
    [TestClass]
    public class ValidateArgumentTest
    {
        [TestMethod]
        public void ObterListaDeMensagensDasExcecoes()
        {
            var result = ValidateArgument.GetMessagesFromExceptions(
                                    Validate.IsNull(null, "object is required"),
                                    Validate.IsNotEmail("email_invalid", "email invalid")
                );

            Assert.IsNotNull(result, "object required");
            Assert.IsTrue(result.Count == 2, "There should be two exceptions");
        }


        [TestMethod]
        public void LancarGrupoDeExcecoes()
        {
            try
            {
                ValidateArgument.IsOkContinue(true,
                                            Validate.IsNull(null, "object is required"),
                                            Validate.IsNotEmail("email_invalid", "email invalid")
                                            );
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Um ou mais erros.", "There should be two exceptions");
            }
        }

        [TestMethod]
        public void LancarUnicaExcecaoComMensagensDoGrupoDeExcecoes()
        {
            try
            {
                ValidateArgument.IsOkContinue(false,
                                            Validate.IsNull(null, "object is required"),
                                            Validate.IsNotEmail("email_invalid", "email invalid")
                                            );
            }
            catch (Exception ex)
            {
                
                Assert.IsTrue(ex.Message.Contains("object is required") && ex.Message.Contains("email invalid"), "There should be two exceptions");
            }
        }

        [TestMethod]
        public void LancarExcecaoIndividual()
        {
            try
            {
                Validate.IsNotNull(null, "object is required", true);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "object is required", "is expected value not null");
            }
        }
    }
}
