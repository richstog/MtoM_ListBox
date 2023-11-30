using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace WinFormsApp1.Classes
{
    public static class DB
    {
        private static NpgsqlConnection _conn = new NpgsqlConnection(
            "Host=localhost;" +
            "Port=5432;" +
            "Username=postgres;" +
            "Password=rhfcbkjdf29;" +
            "Database=test1;"
            );

        public static void openConnection()
        {
            if (_conn.State == System.Data.ConnectionState.Closed)
            {
                _conn.Open();
            }
        }

        public static void closeConnection()
        {
            if (_conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
            }
        }

        public static NpgsqlConnection getConnection()
        {
            return _conn;
        }
    }
}
