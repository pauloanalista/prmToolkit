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
            string stringConexao = "Server=seu ip; Database=nome_do_banco; Port=3306; Uid=usuario; Pwd=senha;";
            
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