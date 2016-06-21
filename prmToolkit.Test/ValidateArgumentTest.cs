using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prmToolkit.Validation;

namespace prmToolkit.Test
{
    [TestClass]
    public class ValidateArgumentTest
    {
        [TestMethod]
        public void GetExceptionCollection()
        {
            var result = ValidateArgument.GetListException(
                                    ValidateArgument.IsNotNull(null, "object is required"),
                                    ValidateArgument.IsEmail("email_invalid", "email invalid")


                );

            Assert.IsNotNull(result, "object required");
            Assert.IsTrue(result.Count == 2, "There should be two exceptions");

        }


        [TestMethod]
        public void ThrowExceptionCollection()
        {

            try
            {
                ValidateArgument.IsOkContinue(
                                            ValidateArgument.IsNotNull(null, "object is required"),
                                            ValidateArgument.IsEmail("email_invalid", "email invalid")
                                            );
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Um ou mais erros.", "There should be two exceptions");
            }
        }

        [TestMethod]
        public void ThrowIndividualException()
        {
            try
            {
                ValidateArgument.IsNotNull(null, "object is required", true);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "object is required", "is expected value not null");
            }
        }
    }
}
