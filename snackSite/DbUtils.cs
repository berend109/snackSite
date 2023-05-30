using System.Data;
using MySql.Data.MySqlClient;

namespace snackSite
{
    public class DbUtils
    {
        public DbUtils()
        {
        }

        public IDbConnection GetDbConnection()
        {
            string connectionString = Program.Configuration
                .GetConnectionString("snackSite")!;

            return new MySqlConnection(connectionString);
        }
    }
}