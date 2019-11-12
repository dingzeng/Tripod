using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Text;

namespace Tripod.Framework.DapperExtentions.Adapters
{
    /// <summary>
    /// The interface for all Dapper.Contrib database operations
    /// Implementing this is each provider's model.
    /// </summary>
    public partial interface ISqlAdapter
    {
        /// <summary>
        /// Inserts <paramref name="entityToInsert"/> into the database, returning the Id of the row created.
        /// </summary>
        /// <param name="connection">The connection to use.</param>
        /// <param name="transaction">The transaction to use.</param>
        /// <param name="commandTimeout">The command timeout to use.</param>
        /// <param name="tableName">The table to insert into.</param>
        /// <param name="columnList">The columns to set with this insert.</param>
        /// <param name="parameterList">The parameters to set for this insert.</param>
        /// <param name="keyProperties">The key columns in this table.</param>
        /// <param name="entityToInsert">The entity to insert.</param>
        /// <returns>The Id of the row created.</returns>
        int Insert(IDbConnection connection, IDbTransaction transaction, int? commandTimeout, string tableName, string columnList, string parameterList, IEnumerable<PropertyInfo> keyProperties, object entityToInsert);

        /// <summary>
        /// Adds the name of a column.
        /// </summary>
        /// <param name="sb">The string builder  to append to.</param>
        /// <param name="columnName">The column name.</param>
        void AppendColumnName(StringBuilder sb, string columnName);
        /// <summary>
        /// Adds a column equality to a parameter.
        /// </summary>
        /// <param name="sb">The string builder  to append to.</param>
        /// <param name="columnName">The column name.</param>
        /// <param name="parameterName">The parameter name.</param>
        void AppendColumnNameEqualsValue(StringBuilder sb, string columnName, string parameterName);
    }
}