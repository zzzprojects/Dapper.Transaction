using System.Data;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{
		/// <summary>
		/// Execute parameterized SQL that selects a single value.
		/// </summary>
		/// <param name="transaction">The transaction to execute on.</param>
		/// <param name="sql">The SQL to execute.</param>
		/// <param name="param">The parameters to use for this command.</param> 
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>The first cell selected as <see cref="object"/>.</returns>
		public static object ExecuteScalar(this IDbTransaction transaction, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).ExecuteScalar(sql, param, transaction, commandTimeout, commandType);
		}

		/// <summary>
		/// Execute parameterized SQL that selects a single value.
		/// </summary>
		/// <param name="transaction">The transaction to execute on.</param>
		/// <param name="command">The command to execute.</param>
		/// <returns>The first cell selected as <see cref="object"/>.</returns>
		public static object ExecuteScalar(this IDbTransaction transaction, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).ExecuteScalar(command);
		}
	}
}