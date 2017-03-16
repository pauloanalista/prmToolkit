using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using System;
using System.Reflection;

namespace prmToolkit.AccessMultipleDatabaseWithAdoNet.Databases
{
    public sealed class DatabaseFactory
    {
        private DatabaseFactory() { }

        public static AbstractDatabase CreateDatabase(EnumDatabaseType enumDatabaseType, string stringDeConexao)
        {

            Type database = null;
            if (enumDatabaseType == EnumDatabaseType.SqlServer)
            {
                database = typeof(SqlServer);
            }
            else if (enumDatabaseType == EnumDatabaseType.MySql)
            {
                database = typeof(MySql);
            }
            else if (enumDatabaseType == EnumDatabaseType.Firebird)
            {
                database = typeof(Firebird);
            }

            try
            {
                // Obtém o construtor
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });

                // Invova o construtor para retornar a instancia
                AbstractDatabase createdObject = (AbstractDatabase)constructor.Invoke(null);

                // Inicializa a propriedade ConnectionString para o banco de dados.
                createdObject.connectionString = stringDeConexao;

                // Retorna a intância com um banco de dados
                return createdObject;
            }
            catch (Exception excep)
            {
                throw new Exception("Erro ao instanciar o banco de dados. " + excep.Message);
            }
        }

    }


}