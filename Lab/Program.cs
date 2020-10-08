using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Transaction;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var connection = new SqlConnection("Server=localhost;Initial Catalog=Z.Dapper.Plus.Lab;Integrated Security=True;"))
            {
                var x1 = connection.ExecuteScalar("SELECT 1");
            }

            using (var connection = new SqlConnection("Server=localhost;Initial Catalog=Z.Dapper.Plus.Lab;Integrated Security=True;"))
            {
                connection.Open();
                var trans = connection.BeginTransaction();
                var x1 = trans.ExecuteScalar("SELECT 1");
            }
        }
    }
}
