using System;
using System.Data;
using System.Windows;
using Microsoft.Data.Sqlite;

namespace Logger
{
    public class Logger
    {
        private const string nameDB = "Data Source=Log.sqlite";
        private SqliteConnection _db;

        public Logger()
        {
            try
            {
                _db = new SqliteConnection("nameDB");
                _db.Open();
                var CreateTable = "CREATE table IF NOT EXISTS Log (id integer PRIMARY KEY AUTOINCREMENT NOT NULL,time text(50) NOT NULL,type text(20) NOT NULL,message text(100) NOT NULL)";
                SqlRequest(CreateTable);
            }
            catch (Exception e)
            {
                string exception = "Во время подключения к Log DB, возникла ошибка SQLite.";
                throw new Exception($"{exception}");
            }
        }

        private void SqlRequest(string sql)
        {
            using (SqliteCommand command = new SqliteCommand())
            {
                try
                {
                    command.Connection = _db;
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    string exception = "Во время записи Log, возникла ошибка SQLite.";
                    throw new Exception($"{exception}");
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