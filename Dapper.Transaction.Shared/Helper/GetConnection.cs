using System;
using System.Data;
using System.Data.Common; 

namespace Dapper.Transaction
{
	internal class InternalGetConnection
	{
		public static IDbConnection GetConnection(IDbTransaction transaction)
		{
			if (transaction.Connection == null)
			{
				throw new Exception("Oops! No connection has been found for the transaction.");
			}

			return transaction.Connection;
		}

		public static DbConnection GetConnection(DbTransaction transaction)
		{
			if (transaction.Connection == null)
			{
				throw new Exception("Oops! No connection has been found for the transaction.");
			}

			return transaction.Connection;
		}
	}
}
