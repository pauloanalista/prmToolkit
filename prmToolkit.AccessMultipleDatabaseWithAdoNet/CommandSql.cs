using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;


namespace prmToolkit.AccessMultipleDatabaseWithAdoNet
{
    public class CommandSql
    {
        private readonly string _stringConnection;

        private readonly string _commandText;

        private readonly List<DbParameter> _parametros;

        private readonly CommandType _commandType;

        private readonly EnumDatabaseType _enumDatabaseType;

        private readonly int _commandTimeout;

        #region Propriedades

        public string StringConnection { get { return _stringConnection; } }

        public string CommandText { get { return _commandText; } }

        public List<DbParameter> Parametros { get { return _parametros; } }

        public CommandType CommandType { get { return _commandType; } }

        public EnumDatabaseType EnumDatabaseType { get { return _enumDatabaseType; } }

        public int CommandTimeout { get { return _commandTimeout; } }

        #endregion

        #region Construtores
        /// <summary>
        /// Realiza consulta no banco de dados com apenas a querie passada por parametro e banco de dados selecionado.
        /// Neste caso não será necessário passar alguns parametros, pois eles receberam os seguintes valores: Parametros=null, CommandTimeout=140, CommandType=Text
        /// </summary>
        /// <param name="stringConnection">String de conexão</param>
        /// <param name="commandText">Querie a ser executada</param>
        /// <param name="enumDatabaseType">Tipo de banco de dados que será realizada a consulta</param>
        public CommandSql(string stringConnection, string commandText, EnumDatabaseType enumDatabaseType)
        {
            this._stringConnection = stringConnection;
            this._commandText = commandText;
            this._parametros = null;
            this._commandType = CommandType.Text;
            this._commandTimeout = 140;
            this._enumDatabaseType = enumDatabaseType;
        }
        /// <summary>
        /// Realiza consulta no banco de dados com apenas os seguintes parametros: querie, parametros e enumDatabaseType.
        /// Neste caso os parametros internos recebem os seguintes valores: CommandTimeout=140, CommandType=Text
        /// </summary>
        /// <param name="stringConnection">String de conexão</param>
        /// <param name="commandText">Querie a ser executada</param>
        /// <param name="parametros">Parametros que foram adicionados a querie</param>
        /// <param name="enumDatabaseType">Tipo de banco de dados que será realizada a consulta</param>
        public CommandSql(string stringConnection, string commandText, List<DbParameter> parametros, EnumDatabaseType enumDatabaseType)
        {
            this._stringConnection = stringConnection;
            this._commandText = commandText;
            this._parametros = parametros;
            this._commandType = CommandType.Text;
            this._commandTimeout = 140;
            this._enumDatabaseType = enumDatabaseType;
        }
        /// <summary>
        /// Realiza consulta no banco de dados.
        /// </summary>
        /// <param name="stringConnection">String de conexão</param>
        /// <param name="commandText">Querie a ser executada</param>
        /// <param name="parametros">Parametros que foram adicionados a querie</param>
        /// <param name="commandType">Tipo de comando que será executado(Text, StoredProcedure, TableDirect)</param>
        /// <param name="commandTimeout">Tempo de execução do comando no banco de dados</param>
        /// <param name="enumDatabaseType">Tipo de banco de dados que será realizada a consulta</param>
        public CommandSql(string stringConnection, string commandText, EnumDatabaseType enumDatabaseType, List<DbParameter> parametros = null, CommandType commandType = CommandType.Text, int commandTimeout = 140)
        {
            this._stringConnection = stringConnection;
            this._commandText = commandText;
            this._parametros = parametros;
            this._commandType = commandType;
            this._commandTimeout = commandTimeout;
            this._enumDatabaseType = enumDatabaseType;
        }

        #endregion
    }
}

