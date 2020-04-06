using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DB
{
    class DatabaseConnection
    {
        string connectionString = "Server=LUUKDEKINDEREN;Database=Skippy;Trusted_Connection=true;";


        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }



    }
}
