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

Neste exemplo caso algum critério não seja atendido irá levantar uma única exceção com todas as mensagens
```sh
public AdicionarFuncionarioResponse AdicionarFuncionario(AdicionarFuncionarioRequest request)
        {
            ValidateArgument.IsOkContinue(false,
                                            Validate.IsNull(request, Mensagens.ARGUMENTO_REQUEST_OBRIGATORIO),
                                            //Valida dados do funcionario
                                            Validate.IsNull(request.Funcionario, Mensagens.ARGUMENTO_FUNCIONARIO_OBRIGATORIO),
                                            Validate.IsNullOrEmpty(request.Funcionario.Nome, Mensagens.ARGUMENTO_FUNCIONARIO_NOME_OBRIGATORIO),
                                            Validate.IsNullOrEmpty(request.Funcionario.Email, Mensagens.ARGUMENTO_FUNCIONARIO_EMAIL_OBRIGATORIO),
                                            Validate.IsNullOrEmpty(request.Funcionario.Senha, Mensagens.ARGUMENTO_FUNCIONARIO_SENHA_OBRIGATORIO),
                                            Validate.IsNullOrEmpty(request.Funcionario.Cpf, Mensagens.ARGUMENTO_FUNCIONARIO_CPF_OBRIGATORIO),
                                            //Valida dados do perfil
                                            Validate.IsNull(request.EnumPerfil, Mensagens.ARGUMENTO_PERFIL_OBRIGATORIO),
                                            //Valida dados da loja
                                            Validate.IsNotGuid(request.LojaId, Mensagens.ARGUMENTO_LOJA_ID_OBRIGATORIO)
                                            );

            //Criptografa a senha
            request.Funcionario.Senha = MD5Crypt.EncryptMD5(request.Funcionario.Senha);

            return _repositorioFuncionario.AdicionarFuncionario(request);
        }

```
Neste exemplo caso algum critério não seja atendido irá levantar retornar uma lista de mensagens sem levantar a exceção
```sh
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
```

Podemos também trabalhar com exceções indivíduais
```sh
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

