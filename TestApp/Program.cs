using System;
using DB_Connection;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlConnect = new MySqlConnecting("mysql60.hostland.ru", "host1323541_irkutsk5", "3306", "host1323541_itstep", "269f43dc");
            
            sqlConnect.Connect();
            var list = sqlConnect.GetData("contacts");
            foreach (var item in list)
            {
                Console.WriteLine(item[0] + " | " + item[1] + " | " + item[2] + " | " + item[3]);
            }
            sqlConnect.Disconnect();
        }
    }
}