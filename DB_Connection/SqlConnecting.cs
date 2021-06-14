/*
 + CONNECTION - (Name || Data Source, Credentials, Optional parameters)
 + Get data from DB
 + Inserting data to DB
 + Updating data in DB
 + Deleting data from DB   
*/

using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DB_Connection
{
    class SqlConnecting
    {
        private SqlConnection _cnn;
        private string _connectionString;

        private string DataSource { get; init; }
        private string Catalog { get; init; }
        private string UserId { get; init; }
        private string Password { get; init; }
        
        private JsonType ConnectionSqlAsync { get; set; }
        public bool IsConnected { get; private set; }

        private async Task SqlConnectingAsync()
        {
            await using FileStream fs = new FileStream("config.json", FileMode.OpenOrCreate);
            ConnectionSqlAsync = await JsonSerializer.DeserializeAsync<JsonType>(fs);
        }
        public SqlConnecting()
        {
            SqlConnectingAsync();
            DataSource = ConnectionSqlAsync.DataSource;
            Catalog = ConnectionSqlAsync.Catalog;
            UserId = ConnectionSqlAsync.UserId;
            Password = ConnectionSqlAsync.Pass;
        }

        public void Connect()
        {
            if (IsConnected) throw new Exception();
            _connectionString = $"Data Source={DataSource};Initial Catalog={Catalog};User ID={UserId};Password={Password}";
            _cnn = new SqlConnection(_connectionString);
            _cnn.Open();
            IsConnected = true;
        }
        
        public void Disconnect()
        {
            if (!IsConnected) throw new Exception();
            _connectionString = $"Data Source={DataSource};Initial Catalog={Catalog};User ID={UserId};Password={Password}";
            _cnn = new SqlConnection(_connectionString);
            _cnn.Close();
            IsConnected = false;
        }

        public string GetData(string tableName)
        {
            if (!IsConnected) throw new Exception();
            SqlCommand command;
            SqlDataReader dataReader;
            String sqlString, output = "";

            sqlString = $"SELECT * FROM {tableName};";

            command = new SqlCommand(sqlString, _cnn);

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                output = output + dataReader.GetValue(0) + "\n";
            }

            return output;
        }

        public void AddData(string tableName, string columnsNames, string data)
        {
            if (!IsConnected) return;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sqlString = "";

            sqlString = $"INSERT INTO {tableName} ({columnsNames}) VALUES({data})";

            command = new SqlCommand(sqlString, _cnn);

            adapter.InsertCommand = new SqlCommand(sqlString, _cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            
            command.Dispose();
        }

        public void UpdateData(string tableName, string updatingData, string id)
        {
            if (!IsConnected) throw new Exception();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sqlString = "";

            sqlString = $"UPDATE {tableName} set {updatingData} where id={id}";
            
            command = new SqlCommand(sqlString, _cnn);
            
            adapter.InsertCommand = new SqlCommand(sqlString, _cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            
            command.Dispose();
        }
        
        public void DeleteData(string tableName, string id)
        {
            if (!IsConnected) throw new Exception();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sqlString = "";

            sqlString = $"DELETE {tableName} WHERE id={id}";
            
            command = new SqlCommand(sqlString, _cnn);
            
            adapter.InsertCommand = new SqlCommand(sqlString, _cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            
            command.Dispose();
        }
    }
}
