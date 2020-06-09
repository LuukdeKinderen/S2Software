using System.Data.SqlClient;

namespace Skippy.Data
{
    class DatabaseConnection
    {
        string connectionString = "Server=mssql.fhict.local;Database=dbi429032_skippy;User Id = dbi429032_skippy; Password=123123q;";


        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }



    }
}
