# prmToolkit

prmToolkit É um projeto responsável por dar apoio a outros projetos.

# Classes
- ValidateArgument
- Encryption

# ValidateArgument
Classe responsável por gerenciar validações de argumentos.

Podemos realizar validações indivíduais ou em grupos.

É possível levantar uma exceção ou captura-las.

### Installation - ValidateArgument

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

```sh
Install-Package prmToolkit.ValidateArgument
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
            //O método GetListException, é responsável por validar parametros e obter uma lista de exceções caso os critérios não sejam atentidos, é possível 	    //capturar o resultado em uma variável.
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
                //O método IsOkContinue, é responsável por validar parametros e disparar a lista de exceções caso os critérios não sejam atendidos
		//Neste caso é necessário utilizar o try catch para capturar as exceções
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
                //É possível fazer validações pontuais e subir uma exceção, mas para isso é necessário passar o último parametro como true
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
# Encryption
Classe responsável por criptografar e descriptografar dados ou mensagens

### Installation - Encryption

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

```sh
Install-Package prmToolkit.Encryption
```
### Exemplo de como usar

```sh
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prmToolkit.Encryption;

namespace prmToolkit.Test
{
    [TestClass]
    public class MD5CryptTest
    {
        [TestMethod]
        public void MD5Crypt_Encrypt_Decrypt()
        {
            string senha = "Paulo Rogério";

            string senhaCriptografada = MD5Crypt.Encrypt(senha);

            string senhaDesCriptografada = MD5Crypt.Decrypt(senhaCriptografada);


            string senhaMD5 = MD5Crypt.EncryptMD5(senha);

            Assert.AreEqual(senhaCriptografada, "sE0hI8fXaecNxoHI2IokuQ==");
            Assert.AreEqual(senhaDesCriptografada, senha);
            Assert.AreEqual(senhaMD5, "69103C8FA326DB8B39CB87A6492390C6");
        }
    }
}
```

