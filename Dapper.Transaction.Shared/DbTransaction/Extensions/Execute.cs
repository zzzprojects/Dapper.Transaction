using System.Data;

namespace Dapper.Transaction 
{
	public static partial class DbTransactionExtensions
	{
		/// <summary>
		/// Execute parameterized SQL.
		/// </summary>
		/// <param name="transaction">The transaction to execute on.</param>
		/// <param name="command">The command to execute on this connection.</param>
		/// <returns>The number of rows affected.</returns>
		public static int Execute(this IDbTransaction transaction, CommandDefinition command)
		{ 
			return InternalGetConnection.GetConnection(transaction).Execute(command);
		}

		/// <summary>
		/// Execute parameterized SQL.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for this query.</param>
		/// <param name="param">The parameters to use for this query.</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>The number of rows affected.</returns>
		public static int Execute(this IDbTransaction transaction, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Execute(sql, param, transaction, commandTimeout, commandType); 
		}

	}
}
