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
        private string UserId { get; set; }
        private string Password { get; init; }
        
        public bool IsConnected { get; private set; }

        public MySqlConnecting( string server, string database, string port, string userId, string password)
        {
            // SqlConnectingAsync();
            Server = server;
            Database = database;
            Port = port;
            UserId = userId;
            Password = password;
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

        /*public IEnumerable<dynamic> GetAllData(string tableName)
        {
             // tbl_users
             // tbl_chat_archive
             // tbl_users_in_chat
             // tbl_chats
             
            if (!IsConnected) throw new Exception();
            MySqlCommand command;
            MySqlDataReader dataReader;
            var sqlString = "";

            var output = new List<Users>() {};

            sqlString = $"SELECT * FROM {tableName};";
            
            command = new MySqlCommand(sqlString, _cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var ex = new Users(Convert.ToInt32(dataReader[0]), Convert.ToString(dataReader[1]), (TypeRole)dataReader[2], (TypeStatus)dataReader[3]);
                switch (tableName)
                { 
                    case "tbl_users":
                    case "tbl_chat_archive":
                        output.Add(ex);
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
        */
        public object GetData(string tableName, string columnsNames, string value)
        {
             // tbl_users
             // tbl_chat_archive
             // tbl_users_in_chat
             // tbl_chats
             
            if (!IsConnected) throw new Exception();

            var sqlString = $"SELECT * FROM {tableName} WHERE ({columnsNames})=({value});";
            
            var command = new MySqlCommand(sqlString, _cnn);
            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                switch (tableName)
                { 
                    case "tbl_users":
                        var outputUsers = new Users(Convert.ToInt32(dataReader[0]), Convert.ToString(dataReader[1]), (TypeRole)dataReader[2], (TypeStatus)dataReader[3]);
                        command.Dispose();
                        return outputUsers;

                    case "tbl_chat_archive":
                        var outputArchive = new ChatArchive(Convert.ToInt32(dataReader[0]), Convert.ToInt32(dataReader[1]), (DateTime)dataReader[2], Convert.ToString(dataReader[3]));
                        command.Dispose();
                        return outputArchive;
                    
                    case "tbl_users_in_chat":
                        var outputInChat = new UsersInChat(Convert.ToInt32(dataReader[0]), Convert.ToInt32(dataReader[1]));
                        command.Dispose();
                        return outputInChat;
                    
                    case "tbl_chats":
                        var outputChats = new ChatsList(Convert.ToInt32(dataReader[0]), Convert.ToString(dataReader[1]), Convert.ToBoolean(dataReader[2]));
                        command.Dispose();
                        return outputChats;
                }
            }
            command.Dispose();
            return 0;
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
