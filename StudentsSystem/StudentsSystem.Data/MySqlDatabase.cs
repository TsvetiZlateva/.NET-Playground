using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsSystem.Data
{
    public class MySqlDatabase : IDisposable
    {
        public MySqlConnection connection;

        public MySqlDatabase(string connectionString)
        {
            this.connection = new MySqlConnection(connectionString);
            this.connection.Open();
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}
