using System.Data;
using System.Threading.Tasks;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{
		/// <summary>
		/// Executes a single-row query, returning the data typed as <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The type of result to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for the query.</param>
		/// <param name="param">The parameters to pass, if any.</param> 
		/// <param name="commandTimeout">The command timeout (in seconds).</param>
		/// <param name="commandType">The type of command to execute.</param>
		/// <returns>
		/// A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
		/// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
		/// </returns>
		public static Task<T> QuerySingleAsync<T>(this IDbTransaction transaction, string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).QuerySingleAsync<T>(sql, param, transaction, commandTimeout, commandType);
		}

		/// <summary>
		/// Executes a query, returning the data typed as <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The type of results to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="command">The command used to query on this connection.</param>
		/// <returns>
		/// A single instance or null of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
		/// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
		/// </returns>
		public static Task<T> QuerySingleAsync<T>(this IDbTransaction transaction, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).QuerySingleAsync<T>(command);
		}
	}
}