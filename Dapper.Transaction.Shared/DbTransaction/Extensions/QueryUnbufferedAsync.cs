#if NET5_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{
        /// <summary>
        /// Execute a query asynchronously using <see cref="IAsyncEnumerable{dynamic}"/>.
        /// </summary>
        /// <param name="this">The transaction to query on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A sequence of data of dynamic data
        /// </returns>
        public static IAsyncEnumerable<dynamic> QueryUnbufferedAsync(this DbTransaction @this, string sql, object? param = null, DbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return InternalGetConnection.GetConnection(@this).QueryUnbufferedAsync(sql, param, transaction, commandTimeout, commandType);            
        }
    }
}
#endif