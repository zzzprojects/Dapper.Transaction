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
        /// Execute a query asynchronously using <see cref="IAsyncEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of results to return.</typeparam>
        /// <param name="this">The connection to query on.</param>
        /// <param name="sql">The SQL to execute for the query.</param>
        /// <param name="param">The parameters to pass, if any.</param>
        /// <param name="transaction">The transaction to use, if any.</param>
        /// <param name="commandTimeout">The command timeout (in seconds).</param>
        /// <param name="commandType">The type of command to execute.</param>
        /// <returns>
        /// A sequence of data of <typeparamref name="T"/>; if a basic type (int, string, etc) is queried then the data from the first column is assumed, otherwise an instance is
        /// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
        /// </returns>
        public static IAsyncEnumerable<T> QueryUnbufferedAsync<T>(this DbTransaction @this, string sql, object? param = null, DbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return InternalGetConnection.GetConnection(@this).QueryUnbufferedAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }
    }
}
#endif