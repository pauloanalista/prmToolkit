using prmToolkit.AccessMultipleDatabaseWithAdoNet.Databases;
using prmToolkit.AccessMultipleDatabaseWithAdoNet.Helpers.Mapper;
using System.Collections.Generic;
using System.Data;


namespace prmToolkit.AccessMultipleDatabaseWithAdoNet
{
    public abstract class AbstractRepository
    {
        /// <summary>
        /// Obtém uma lista de objetos ou entidade vinda do banco de dados.
        /// </summary>
        /// <typeparam name="TDto">Tipo de objeto que deseja retornar na lista</typeparam>
        /// <param name="comandoSql">Parametros necessários para realizar a consulta no banco de dados</param>
        /// <returns>Retorna uma lista de objeto preenchido com as informações do banco de dados</returns>
        protected IEnumerable<TDto> GetCollection<TDto>(CommandSql comandoSql) where TDto : class, new()
        {
            AbstractDatabase database = DatabaseFactory.CreateDatabase(comandoSql.EnumDatabaseType, comandoSql.StringConnection);
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand(comandoSql.CommandText, connection))
                {
                    //Adiciona os parametros no command
                    if (comandoSql.Parametros != null)
                    {
                        comandoSql.Parametros.ForEach(x => command.Parameters.Add(x));
                    }

                    //Define configurações do command
                    command.CommandType = comandoSql.CommandType;
                    command.CommandTimeout = comandoSql.CommandTimeout;
                    command.CommandText = comandoSql.CommandText;

                    //Converte o datareader em List
                    List<TDto> objectCollection = new List<TDto>();
                    objectCollection = ObjectMapper.FillCollection<TDto>(command.ExecuteReader());

                    return objectCollection;

                }
            }
        }
    }
}
