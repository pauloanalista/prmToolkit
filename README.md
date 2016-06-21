# prmToolkit

prmToolkit É um projeto responsável por dar apoio a outros projetos.

# ValidateArgument
Classe responsável por gerenciar validações de argumentos.

VANTAGENS
>Podemos realizar validações indivíduais ou em grupos

>É possível levantar uma exceção ou captura-las

### Version
1.0.0

### Autor
Paulo Rogério

### Installation

Para instalar o, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

```sh
Install-Package prmToolkit -Version 1.0.1
```

### Exemplo de como usar

```sh
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
```
