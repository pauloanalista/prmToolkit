# prmToolkit

prmToolkit É um projeto responsável por dar apoio a outros projetos.

# Classes
- ArgumentsValidator
- Encryption
- AccessMultipleDatabaseWithAdoNet

# ArgumentsValidator
Classe responsável por gerenciar validações de argumentos.

Podemos realizar validações indivíduais ou em grupos.

É possível levantar uma exceção ou captura-las.

### Installation - ArgumentsValidator

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia a dll
```sh
Install-Package prmToolkit.ArgumentsValidator
```

Para adicionar somente as classes
```sh
Install-Package prmToolkit.ArgumentsValidator-Source
```
### Exemplo de como usar

```sh
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
    }
}

```

# Notification
Classe responsável por validar argumentos, sem levantar exceções, com ela é possível adicionar mensagens em várias camadas do projeto e obter essas notificações de forma centralizada. Também é possível saber se a requisição é válida.

### Installation - Notification

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia a dll
```sh
Install-Package prmToolkit.Notification
```

Para adicionar somente as classes
```sh
Install-Package prmToolkit.Notification-Source
```
### Exemplo de como usar

```sh
            //Iniciar o monitoramento das mensagens, normalmente ficara em um base da controller da api
            NotificationManager.Start();

            //Validacoes que irao ocorrer em várias camadas do sistema
            string nome = string.Empty;
            int idade = 35;
            string variavel = "123455";

            //Camada de serviços de aplicacao
            //O último parametro é opcional, ele pega o nome do método que está executando a validação automaticamente, caso queira 
            //customizar o nome, é só informar no parametro
            AddNotification.IfEmpty(nome, "Nome é obrigatório", "Nome do método que está executando a validação");

            //Camada de serviços (Dominio)
            AddNotification.IfNotGreaterThan(idade, 100, "Idade deve ser maior que 100");

            //Camada de infra
            AddNotification.IfNotGuid(variavel, "Nao é um guid válido");

            //Verifica se todas as validações estão de válidas
            bool valid = NotificationManager.IsValid();

            //Obtém a lista de mensagens para apresentar para o usuário
            var lista = NotificationManager.GetNotifications();

            //Limpa lista de notificações, usado quando você finaliza seu request
            NotificationManager.End();

       
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

# DateTimeExtension
Classe responsável por adicionar novos recursos no DateTime.

### Installation - Notification

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia a dll
```sh
Install-Package prmToolkit.DateTimeExtension
```

Para adicionar somente a classe
```sh
Install-Package prmToolkit.DateTimeExtension-Source
```
### Recursos disponíveis
- StartOfDay
- EndOfDay
- FirstDayOfMonth
- LastDayOfMonth
- FirstDayOfWeek
- LastDayOfWeek
- EndOfLastDayOfMonth
- IsInPeriod
- IsOutOfPeriod

# AccessMultipleDatabaseWithAdoNet
Acesse mais de um tipo de banco de dados de forma fácil via ADO.NET.



Atualmente dando suporte aos bancos.

- SqlServer

- MySql

- Firebird



É possível implementar outros bancos de dados de forma fácil!

### Installation - AccessMultipleDatabaseWithAdoNet

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia a dll
```sh
Install-Package prmToolkit.AccessMultipleDatabaseWithAdoNet
```

Para adicionar somente as classes
```sh
Install-Package prmToolkit.AccessMultipleDatabaseWithAdoNet-Source
```
### Exemplo de como usar

```sh
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prmToolkit.AccessMultipleDatabaseWithAdoNet;
using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using System.Collections.Generic;
using System.Linq;
namespace prmToolkit.Test
{

    [TestClass]
    public class AccessMultipleDatabaseWithAdoNetTest : AbstractRepository //herrda
    {
        [TestMethod()]
        public void ObterDadosTest()
        {
            //Define a string de conexão
            string  stringConexao = "Server=seu ip; Database=nome_do_banco; Port=3306; Uid=usuario; Pwd=senha;"
            
            //Monta a query
            string query = @"select u.nome, u.login, u.senha from usuario u;";
            
            //Define em que banco será executada a aquery
            CommandSql cmd = new CommandSql(stringConexao, query, EnumDatabaseType.MySql);

            //Obtem os dados do banco de dados MySql
            List<Usuario> usuarios = GetCollection<Usuario>(cmd)?.ToList();


            Assert.IsTrue(usuarios.Count() > 0);
        }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}

```
