using System;
using MySql.Data.MySqlClient;

namespace DB_Connection
{
    public class DataBase
    {
        static string commandText = "create table table_name(column_1 int null);";
        static string connectionString = "Database=host1323541_irkutsk2;Data Source=mysql60.hostland.ru;User Id=host1323541_itstep;Password=269f43dc";
        public DataBase()
        {
           // public MySqlConnection conn = new MySqlConnection(connectionString);
           // MySqlCommand myCommand = new MySqlCommand(commandText, conn);
           // conn.Open();
           // myCommand.ExecuteNonQuery();
           // conn.Close();
        }
    }
}