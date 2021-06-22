/*
 + CONNECTION - (Name || Data Source, Credentials, Optional parameters)
 + Get data from DB
 + Inserting data to DB
 + Updating data in DB
 + Deleting data from DB   
 TODO Filter data
*/

using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using DataModel;

namespace DB_Connection
{
    public class MySqlConnecting
    {
        private MySqlConnection _cnn;
        private string _connectionString;

        private string Server { get; init; }
        private string Database { get; init; }
        
        private string Port { get; init; }
        private string UserId { get; init; }
        private string Password { get; init; }
        
        public bool IsConnected { get; private set; }

        public MySqlConnecting()
        {
            // SqlConnectingAsync();
            Server = "mysql60.hostland.ru";
            Database = "host1323541_irkutsk5";
            Port = "3306";
            UserId = "host1323541_itstep";
            Password = "269f43dc";
        }

        public void Connect()
        {
            if (IsConnected) throw new Exception();
            
            _connectionString = $"Server={Server};Database={Database};Uid={UserId};Pwd={Password}";
            _cnn = new MySqlConnection (_connectionString);
            _cnn.Open();
            IsConnected = true;
        }
        
        public void Disconnect()
        {
            if (!IsConnected) throw new Exception();
            _cnn = new MySqlConnection (_connectionString);
            _cnn.Close();
            IsConnected = false;
        }

        public List<dynamic> GetData(string tableName)
        {
            /*
             * tbl_users
             * tbl_chat_archive
             * tbl_users_in_chat
             * tbl_chats
             */
            if (!IsConnected) throw new Exception();
            MySqlCommand command;
            MySqlDataReader dataReader;
            var sqlString = "";

            var output = new List<dynamic>() {};

            sqlString = $"SELECT * FROM {tableName};";
            
            command = new MySqlCommand(sqlString, _cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                switch (tableName)
                {
                    case "tbl_users":
                    case "tbl_chat_archive":
                       
                            output.Add(new dynamic[]
                            {
                                dataReader.GetValue(0), 
                                dataReader.GetValue(1), 
                                dataReader.GetValue(2),
                                dataReader.GetValue(3)
                            });
                        break;
                    case "tbl_users_in_chat":
                        output.Add(new dynamic[] 
                        {
                            dataReader.GetValue(0), 
                            dataReader.GetValue(1)
                        });
                        break;
                    case "tbl_chats":
                        output.Add(new dynamic[]
                        {
                            dataReader.GetValue(0),
                            dataReader.GetValue(1),
                            dataReader.GetValue(2)
                        });
                        break;
                }
            }
            command.Dispose();
            return output;
        }
        
        public void AddData(string tableName, string columnsNames, string data)
        {
            if (!IsConnected) return;
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String sqlString = "";

            sqlString = $"INSERT INTO {tableName} ({columnsNames}) VALUES({data})";

            command = new MySqlCommand(sqlString, _cnn);

            adapter.InsertCommand = new MySqlCommand(sqlString, _cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            
            command.Dispose();
        }

        public void UpdateData(string tableName, string updatingData, string id)
        {
            if (!IsConnected) throw new Exception();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String sqlString = "";

            sqlString = $"UPDATE {tableName} set {updatingData} where id={id}";
            
            command = new MySqlCommand(sqlString, _cnn);
            
            adapter.InsertCommand = new MySqlCommand(sqlString, _cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            
            command.Dispose();
        }
        
        public void DeleteData(string tableName, string id)
        {
            if (!IsConnected) throw new Exception();
            MySqlCommand command;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String sqlString = "";

            sqlString = $"DELETE FROM {tableName} WHERE id={id}";
            
            command = new MySqlCommand(sqlString, _cnn);
            
            adapter.InsertCommand = new MySqlCommand(sqlString, _cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            
            command.Dispose();
        }
    }
}
