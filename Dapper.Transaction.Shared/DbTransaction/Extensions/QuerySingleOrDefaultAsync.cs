using System;
using System.Data;
using System.Threading.Tasks;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{
		/// <summary>
		/// Execute a single-row query asynchronously using Task.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="command">The command used to query on this connection.</param>
		/// <remarks>Note: the row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
		public static Task<dynamic> QuerySingleOrDefaultAsync(this IDbTransaction transaction, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).QuerySingleOrDefaultAsync(command);
		}

		/// <summary>
		/// Execute a single-row query asynchronously using Task.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="type">The type to return.</param>
		/// <param name="command">The command used to query on this connection.</param>
		public static Task<object> QuerySingleOrDefaultAsync(this IDbTransaction transaction, Type type, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).QuerySingleOrDefaultAsync(type, command);
		}

		/// <summary>
		/// Execute a single-row query asynchronously using Task.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for the query.</param>
		/// <param name="param">The parameters to pass, if any.</param> 
		/// <param name="commandTimeout">The command timeout (in seconds).</param>
		/// <param name="commandType">The type of command to execute.</param>
		public static Task<dynamic> QuerySingleOrDefaultAsync(this IDbTransaction transaction, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).QuerySingleOrDefaultAsync(sql, param, transaction, commandTimeout, commandType);
		}

		/// <summary>
		/// Execute a single-row query asynchronously using Task.
		/// </summary>
		/// <param name="transaction">The connection to query on.</param>
		/// <param name="type">The type to return.</param>
		/// <param name="sql">The SQL to execute for the query.</param>
		/// <param name="param">The parameters to pass, if any.</param> 
		/// <param name="commandTimeout">The command timeout (in seconds).</param>
		/// <param name="commandType">The type of command to execute.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type"/> is <c>null</c>.</exception>
		public static Task<object> QuerySingleOrDefaultAsync(this IDbTransaction transaction, Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).QuerySingleOrDefaultAsync(type, sql, param, transaction, commandTimeout, commandType);
		}
	}
}