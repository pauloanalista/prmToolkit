using Microsoft.VisualStudio.TestTools.UnitTesting;
using prmToolkit.AccessMultipleDatabaseWithAdoNet;
using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using prmToolkit.AccessMultipleDatabaseWithAdoNet.Databases;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace prmToolkit.Test
{

    [TestClass]
    public class AccessMultipleDatabaseWithAdoNetTest : AbstractRepository
    {
        [TestMethod()]
        public void ObterDadosTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Debug.WriteLine("Início: " + stopwatch.Elapsed.TotalMilliseconds);

            string query = @"select u.nome, u.login, u.senha
                    from usuario u;
                    ";

            CommandSql cmd = new CommandSql("Server=seu ip; Database=nome_do_banco; Port=3306; Uid=usuario; Pwd=senha;",
                                            query, EnumDatabaseType.MySql);

            

            List<Usuario> permissoes = GetCollection<Usuario>(cmd)?.ToList();

            stopwatch.Stop();
            Debug.WriteLine("Fim: " + stopwatch.Elapsed.TotalMilliseconds);

            Assert.IsTrue(permissoes.Count() > 0);
        }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}