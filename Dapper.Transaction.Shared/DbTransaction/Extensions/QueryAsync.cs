using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{
		/// <summary>
		/// Execute a query asynchronously using Task.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for the query.</param>
		/// <param name="param">The parameters to pass, if any.</param> 
		/// <param name="commandTimeout">The command timeout (in seconds).</param>
		/// <param name="commandType">The type of command to execute.</param>
		/// <remarks>Note: each row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
		public static Task<IEnumerable<dynamic>> QueryAsync(this IDbTransaction transaction, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).QueryAsync(sql, param, transaction, commandTimeout, commandType);
		}


		/// <summary>
		/// Execute a query asynchronously using Task.
		/// </summary>
		/// <param name="cnn">The connection to query on.</param>
		/// <param name="type">The type to return.</param>
		/// <param name="sql">The SQL to execute for the query.</param>
		/// <param name="param">The parameters to pass, if any.</param>
		/// <param name="commandTimeout">The command timeout (in seconds).</param>
		/// <param name="commandType">The type of command to execute.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type"/> is <c>null</c>.</exception>
		public static Task<IEnumerable<dynamic>> QueryAsync(this IDbTransaction transaction, Type type, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).QueryAsync(type, sql, param, transaction, commandTimeout, commandType);
		}

		/// <summary>
		/// Execute a query asynchronously using Task.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="command">The command used to query on this connection.</param>
		/// <remarks>Note: each row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
		public static Task<IEnumerable<dynamic>> QueryAsync(this IDbTransaction transaction, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).QueryAsync(command);
		}

		/// <summary>
		/// Execute a query asynchronously using Task.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="type">The type to return.</param>
		/// <param name="command">The command used to query on this connection.</param>
		public static Task<IEnumerable<object>> QueryAsync(this IDbTransaction transaction, Type type, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).QueryAsync(type, command);
		}
	}
}