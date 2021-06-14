using System;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace Server
{
    public class SQL
    {
        private MySqlConnection db;
        private string connectSTR;
        public SQL()
        {
            connectSTR = "Server=mysql60.hostland.ru;Database=host1323541_irkutsk6;Uid=host1323541_itstep;Pwd=269f43dc;";
        }

        public SQL(string server,string dataBase, string login, string pass)
        {
            connectSTR = $"Server={server};Database={dataBase};Uid={login};Pwd={pass};";
        }

        public void Connect()//TODO при подключении дописать проверку таблиц
        {
            db = new MySqlConnection();
            db.Open();
            
            if (db.Ping())
            {
                Console.WriteLine("Подключились успешно к MySQL");
            }
            else
            {
                Console.WriteLine("Ошибка подключения к MySQL");
            }
        }

        public void Insert(string table)//TODO дописать функцию
        {
            string sql = $"INSERT INTO {table} (name, age, is_study) VALUES ('{1}', {2}, {3})";
            var query = new MySqlCommand
            {
                Connection = db,
                CommandText = sql
            };
            var res = query.ExecuteNonQuery();
            
            if (res == 1)
            {
                Console.WriteLine("Данные добавились");
            }
        }
        
        public void Select(string table)//TODO дописать функцию
        {
            string sql = $"SELECT * FROM {table}";
            var query = new MySqlCommand
            {
                Connection = db,
                CommandText = sql
            };
            var res = query.ExecuteReader();
            
            
            res.Close();
        }
        
        public void Update(string table,string where)//TODO дописать функцию
        {
            string sql = $"UPDATE {table} (name, age, is_study) VALUES ('{1}', {2}, {3}) WHERE {where}";
            var query = new MySqlCommand
            {
                Connection = db,
                CommandText = sql
            };
            var res = query.ExecuteNonQuery();
            if (res == 1)
            {
                Console.WriteLine("Данные добавились");
            }
        }

        public void Disconnect()
        {
            db.Close();
        }
    }
}