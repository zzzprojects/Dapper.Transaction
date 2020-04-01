using System.Data;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{
		/// <summary>
		/// Execute a command that returns multiple result sets, and access each in turn.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for this query.</param>
		/// <param name="param">The parameters to use for this query.</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		public static SqlMapper.GridReader QueryMultiple(this IDbTransaction transaction, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).QueryMultiple(sql, param, transaction, commandTimeout, commandType);
		}

		/// <summary>
		/// Execute a command that returns multiple result sets, and access each in turn.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="command">The command to execute for this query.</param>
		public static SqlMapper.GridReader QueryMultiple(this IDbTransaction transaction, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).QueryMultiple(command);
		}
	}
}