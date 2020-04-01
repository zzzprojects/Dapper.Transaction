using System.Data;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{ 
		/// <summary>
		/// Execute parameterized SQL that selects a single value.
		/// </summary>
		/// <typeparam name="T">The type to return.</typeparam>
		/// <param name="transaction">The transaction to execute on.</param>
		/// <param name="sql">The SQL to execute.</param>
		/// <param name="param">The parameters to use for this command.</param> 
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>The first cell returned, as <typeparamref name="T"/>.</returns>
		public static T ExecuteScalar<T>(this IDbTransaction transaction, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
		}


		/// <summary>
		/// Execute parameterized SQL that selects a single value.
		/// </summary>
		/// <typeparam name="T">The type to return.</typeparam>
		/// <param name="transaction">The transaction to execute on.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>The first cell selected as <typeparamref name="T"/>.</returns>
		public static T ExecuteScalar<T>(this IDbTransaction transaction, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).ExecuteScalar<T>(command);
		}
	}
}