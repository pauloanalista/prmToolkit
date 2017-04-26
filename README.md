# prmToolkit

prmToolkit É um projeto responsável por dar apoio a outros projetos.

# Classes
- ArgumentsValidator
- Notification
- Encryption
- DateTimeExtension
- EnumExtension
- AccessMultipleDatabaseWithAdoNet
- Log
- Faker
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

### Installation - DateTimeExtension

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
 
# EnumExtension
Classe responsável por adicionar novos recursos ao Enum.

### Installation - EnumExtension

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia da dll
```sh
Install-Package prmToolkit.EnumExtension
```
### Recursos disponíveis
- GetDescription (obtém a descrição do enum)
- ToEnum (Obtém o Enum através do nome passado)
- GetAttribute (Obtém o atributo customizado do enum)

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
    public class AccessMultipleDatabaseWithAdoNetTest : AbstractRepository 
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

# Log
Pacote responsável por gerenciar os logs da aplicação.

Suporte a gravação de log:
- File
- EventViewer
- Database (MySql, SqlServer e Firebird)

Recursos
Todo o comportamento do log deve ser informado diretamente no arquivo de configuração de seu projeto, com isso caso seja necessário mudar a estratégia de gravação de log, você não precisa recompilar sua aplicação.


### Installation - Log

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar a referencia a dll
```sh
Install-Package prmToolkit.Log
```

### Exemplo de como configurar o log

Após adicionar o pacote prmToolkit.Log em seu projeto, configure seu (WebConfig ou AppConfig) conforme abaixo:


```sh
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <!--EnumDatabaseType = SqlServer = 0, MySql = 1, Firebird = 2-->
    <!--EnumExceptionDetail = Simple = 0, Synthetic = 1, Analytical = 2-->
    <!--EnumLogType = SaveToFile = 0, SaveToDatabase = 1, SaveToEventViewer = 2-->
    <!--EnumMessageType = Information = 0, Warning = 1, Error = 2 -->

    <!--Irá salvar o log em todos lugares definidos aqui-->
    <add key="Log_SaveAll_Set_Sequence_EnumLogType" value="1, 0, 2"/>

    <!--
    Irá salvar o log no modo de contigência, caso o log principal de algum erro o contigência é acionado. 
    Ele irá gravar para o primeiro tipo de log informado, caso não consiga ele tenta o segundo tipo de log informado e assim sucessivamente
    -->
    <add key="Log_TrySave_Set_Sequence_EnumLogType_Contingency" value="0"/>

    <!--Define que tipo de banco de dados você quer armazenar o log MySql, SqlServer ou Firebird-->
    <add key="Log_Database_Set_EnumDatabaseType" value="1"/>

    <!--Define o nível de detalhamento do log, podendo ser log simples, sintético ou analitico-->
    <add key="Log_Detail_Set_EnumExceptionDetail" value="0"/>

    <!--Aqui definimos que tipo de mensagem tem permissão de ser armazenado, podendo ser Information, Warning e Error-->
    <add key="Log_MessageType_View" value="0, 1, 2"/>

    <!--Define o nome da aplicação que está sendo logado-->
    <add key="Log_ApplicationName" value="prmToolkit"/>

    <!--Define onde será gravado o log em arquivo-->
    <add key="Log_File_Set_FolderPath" value="C:\_Paulo\Logs"/>
  </appSettings>

  <connectionStrings>
    <clear />
    <!--Local-->
    <add name="Log_ConnectionString" providerName="SQLOLEDB" connectionString="Server=localhost; Database=samich_log; Port=3306; Uid=root; Pwd=MySQL@dmin;" />
  </connectionStrings>

  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
  </startup>
</configuration>

```

### Exemplo de como usar

```sh
 
 LogManager.Save("Minha mensagem", EnumMessageType.Information)
 
```


# Faker
Classe responsável por criar dados falsos para usar na aplicação.

### Installation - Faker

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia a dll
```sh
Install-Package prmToolkit.Faker
```

É possível criar dados falsos para.
- Address
- Company
- CreditCard
- Education
- GeoLocation
- Internet
- Lorem
- Name
- PhoneNumber
- etc

### Exemplo de como usar

```sh
 
 Faker.Name.GetFirstName();
 Faker.Company.GetName();
 Faker.CreditCard.CreditCardNumber();
 
```
