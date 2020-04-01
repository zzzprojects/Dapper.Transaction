using System;
using System.Collections.Generic;
using System.Data;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{
		/// <summary>
		/// Executes a query, returning the data typed as <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The type of results to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for the query.</param>
		/// <param name="param">The parameters to pass, if any.</param> 
		/// <param name="buffered">Whether to buffer results in memory.</param>
		/// <param name="commandTimeout">The command timeout (in seconds).</param>
		/// <param name="commandType">The type of command to execute.</param>
		/// <returns>
		/// A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
		/// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
		/// </returns>
		public static IEnumerable<T> Query<T>(this IDbTransaction transaction, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
		}

		/// <summary>
		/// Executes a query, returning the data typed as <typeparamref name="T"/>.
		/// </summary>
		/// <typeparam name="T">The type of results to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="command">The command used to query on this connection.</param>
		/// <returns>
		/// A sequence of data of <typeparamref name="T"/>; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
		/// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
		/// </returns>
		public static IEnumerable<T> Query<T>(this IDbTransaction transaction, CommandDefinition command)
		{
			return InternalGetConnection.GetConnection(transaction).Query<T>(command);
		}

		/// <summary>
		/// Perform a multi-mapping query with 2 input types.
		/// This returns a single type, combined from the raw types via <paramref name="map"/>.
		/// </summary>
		/// <typeparam name="TFirst">The first type in the recordset.</typeparam>
		/// <typeparam name="TSecond">The second type in the recordset.</typeparam>
		/// <typeparam name="TReturn">The combined type to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for this query.</param>
		/// <param name="map">The function to map row types to the return type.</param>
		/// <param name="param">The parameters to use for this query.</param> 
		/// <param name="buffered">Whether to buffer the results in memory.</param>
		/// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>An enumerable of <typeparamref name="TReturn"/>.</returns>
		public static IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(this IDbTransaction transaction, string sql, Func<TFirst, TSecond, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query<TFirst, TSecond, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
		}

		/// <summary>
		/// Perform a multi-mapping query with 3 input types.
		/// This returns a single type, combined from the raw types via <paramref name="map"/>.
		/// </summary>
		/// <typeparam name="TFirst">The first type in the recordset.</typeparam>
		/// <typeparam name="TSecond">The second type in the recordset.</typeparam>
		/// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TReturn">The combined type to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for this query.</param>
		/// <param name="map">The function to map row types to the return type.</param>
		/// <param name="param">The parameters to use for this query.</param>
		/// <param name="buffered">Whether to buffer the results in memory.</param>
		/// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>An enumerable of <typeparamref name="TReturn"/>.</returns>
		public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(this IDbTransaction transaction, string sql, Func<TFirst, TSecond, TThird, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query<TFirst, TSecond, TThird, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
		}


		/// <summary>
		/// Perform a multi-mapping query with 4 input types.
		/// This returns a single type, combined from the raw types via <paramref name="map"/>.
		/// </summary>
		/// <typeparam name="TFirst">The first type in the recordset.</typeparam>
		/// <typeparam name="TSecond">The second type in the recordset.</typeparam>
		/// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TReturn">The combined type to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for this query.</param>
		/// <param name="map">The function to map row types to the return type.</param>
		/// <param name="param">The parameters to use for this query.</param> 
		/// <param name="buffered">Whether to buffer the results in memory.</param>
		/// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>An enumerable of <typeparamref name="TReturn"/>.</returns>
		public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbTransaction transaction, string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query<TFirst, TSecond, TThird, TFourth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
		}

		/// <summary>
		/// Perform a multi-mapping query with 5 input types.
		/// This returns a single type, combined from the raw types via <paramref name="map"/>.
		/// </summary>
		/// <typeparam name="TFirst">The first type in the recordset.</typeparam>
		/// <typeparam name="TSecond">The second type in the recordset.</typeparam>
		/// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
		/// <typeparam name="TReturn">The combined type to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for this query.</param>
		/// <param name="map">The function to map row types to the return type.</param>
		/// <param name="param">The parameters to use for this query.</param> 
		/// <param name="buffered">Whether to buffer the results in memory.</param>
		/// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>An enumerable of <typeparamref name="TReturn"/>.</returns>
		public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(this IDbTransaction transaction, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
		}

		/// <summary>
		/// Perform a multi-mapping query with 6 input types.
		/// This returns a single type, combined from the raw types via <paramref name="map"/>.
		/// </summary>
		/// <typeparam name="TFirst">The first type in the recordset.</typeparam>
		/// <typeparam name="TSecond">The second type in the recordset.</typeparam>
		/// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
		/// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
		/// <typeparam name="TReturn">The combined type to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for this query.</param>
		/// <param name="map">The function to map row types to the return type.</param>
		/// <param name="param">The parameters to use for this query.</param> 
		/// <param name="buffered">Whether to buffer the results in memory.</param>
		/// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>An enumerable of <typeparamref name="TReturn"/>.</returns>
		public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(this IDbTransaction transaction, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
		}

		/// <summary>
		/// Perform a multi-mapping query with 7 input types. If you need more types -> use Query with Type[] parameter.
		/// This returns a single type, combined from the raw types via <paramref name="map"/>.
		/// </summary>
		/// <typeparam name="TFirst">The first type in the recordset.</typeparam>
		/// <typeparam name="TSecond">The second type in the recordset.</typeparam>
		/// <typeparam name="TThird">The third type in the recordset.</typeparam>
		/// <typeparam name="TFourth">The fourth type in the recordset.</typeparam>
		/// <typeparam name="TFifth">The fifth type in the recordset.</typeparam>
		/// <typeparam name="TSixth">The sixth type in the recordset.</typeparam>
		/// <typeparam name="TSeventh">The seventh type in the recordset.</typeparam>
		/// <typeparam name="TReturn">The combined type to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for this query.</param>
		/// <param name="map">The function to map row types to the return type.</param>
		/// <param name="param">The parameters to use for this query.</param> 
		/// <param name="buffered">Whether to buffer the results in memory.</param>
		/// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>An enumerable of <typeparamref name="TReturn"/>.</returns>
		public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this IDbTransaction transaction, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(sql, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
		}

		/// <summary>
		/// Perform a multi-mapping query with an arbitrary number of input types.
		/// This returns a single type, combined from the raw types via <paramref name="map"/>.
		/// </summary>
		/// <typeparam name="TReturn">The combined type to return.</typeparam>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for this query.</param>
		/// <param name="types">Array of types in the recordset.</param>
		/// <param name="map">The function to map row types to the return type.</param>
		/// <param name="param">The parameters to use for this query.</param>
		/// <param name="buffered">Whether to buffer the results in memory.</param>
		/// <param name="splitOn">The field we should split and read the second object from (default: "Id").</param>
		/// <param name="commandTimeout">Number of seconds before command execution timeout.</param>
		/// <param name="commandType">Is it a stored proc or a batch?</param>
		/// <returns>An enumerable of <typeparamref name="TReturn"/>.</returns>
		public static IEnumerable<TReturn> Query<TReturn>(this IDbTransaction transaction, string sql, Type[] types, Func<object[], TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query<TReturn>(sql, types, map, param, transaction, buffered, splitOn, commandTimeout, commandType);
		}

	}
}