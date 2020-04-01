﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Dapper.Transaction
{
	public static partial class DbTransactionExtensions
	{
		/// <summary>
		/// Return a sequence of dynamic objects with properties matching the columns.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="sql">The SQL to execute for the query.</param>
		/// <param name="param">The parameters to pass, if any.</param>
		/// <param name="buffered">Whether to buffer the results in memory.</param>
		/// <param name="commandTimeout">The command timeout (in seconds).</param>
		/// <param name="commandType">The type of command to execute.</param>
		/// <remarks>Note: each row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</remarks>
		public static IEnumerable<dynamic> Query(this IDbTransaction transaction, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query(sql, param, transaction, buffered, commandTimeout, commandType);
		}


		/// <summary>
		/// Executes a single-row query, returning the data typed as <paramref name="type"/>.
		/// </summary>
		/// <param name="transaction">The transaction to query on.</param>
		/// <param name="type">The type to return.</param>
		/// <param name="sql">The SQL to execute for the query.</param>
		/// <param name="param">The parameters to pass, if any.</param>
		/// <param name="buffered">Whether to buffer results in memory.</param>
		/// <param name="commandTimeout">The command timeout (in seconds).</param>
		/// <param name="commandType">The type of command to execute.</param>
		/// <exception cref="ArgumentNullException"><paramref name="type"/> is <c>null</c>.</exception>
		/// <returns>
		/// A sequence of data of the supplied type; if a basic type (int, string, etc) is queried then the data from the first column in assumed, otherwise an instance is
		/// created per row, and a direct column-name===member-name mapping is assumed (case insensitive).
		/// </returns>
		public static IEnumerable<dynamic> Query(this IDbTransaction transaction, Type type, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
		{
			return InternalGetConnection.GetConnection(transaction).Query(type, sql, param, transaction, buffered, commandTimeout, commandType);
		} 
	}
}