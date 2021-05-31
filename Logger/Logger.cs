using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Logger
{
    public class Logger
    {
        private const string nameBD = "Data Source=Log.sqlite";
        private SqliteConnection bd;

        public Logger()
        {
            try
            {
                bd = new SqliteConnection("nameBD");
                bd.Open();
                var CreateTable = "CREATE table IF NOT EXISTS Log (id integer PRIMARY KEY AUTOINCREMENT NOT NULL,time text(50) NOT NULL,type text(20) NOT NULL,message text(100) NOT NULL)";
                SqlRequest(CreateTable);
            }
            catch (Exception e)
            {
                Console.WriteLine("e");
                throw new Exception($"{e}");
            }
        }

        private void SqlRequest(string message)
        {
            using (SqliteCommand command = new SqliteCommand())
            {
                try
                {
                    command.Connection = bd;
                    command.CommandText = "message";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("e");
                    throw new Exception($"{e}");
                }
            }
        }
        public void CustomLog(string type,string message)
        {
            var sqlRequest = $"INSERT INTO Log (time,type,message) VALUES ('{DateTime.Now:G}', '{type}', '{message}');";
            SqlRequest(sqlRequest);
        }
        public void TypeLog(LogType type,string message)
        {
            var sqlRequest = $"INSERT INTO Log (time,type,message) VALUES ('{DateTime.Now:G}', '{type.ToString()}', '{message}');";
            SqlRequest(sqlRequest);
        }

        public void Info(string message)
        {
            TypeLog(LogType.Info, message);
        }
        public void Success(string message)
        {
            TypeLog(LogType.Success, message);
        }
        public void Warning(string message)
        {
            TypeLog(LogType.Warning, message);
        }
        public void Error(string message)
        {
            TypeLog(LogType.Error, message);
        }
    }
}