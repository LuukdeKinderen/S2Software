using System.Data.SqlClient;

namespace Skippy.Data
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
