using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Infrastructure.DB
{
    public class DbInitializer
    {
        private static string _connectionString = "Server=.;Database=DVLD;User Id=sa;Password=sa123456";

        public static SqlConnection Connection()
        {
            return new SqlConnection(_connectionString);
        }


    }
}
