/*
 + CONNECTION - (Name || Data Source, Credentials, Optional parameters)
 + Get data from DB
 + Inserting data to DB
 + Updating data in DB
 + Deleting data from DB   
*/

using System;
using System.Data.SqlClient;

namespace DB_Connection
{
    public class SqlConnecting
    {
        private SqlConnection _cnn;
        private string _connectionString;

        private string DataSource { get; init; }
        private string Catalog { get; init; }
        private string UserId { get; init; }
        private string Password { get; init; }
        public bool IsConnected { get; private set; }
        public SqlConnecting(string dataSource, string catalog, string userId, string password)
        {
            IsConnected = false;
            DataSource = dataSource;
            Catalog = catalog;
            UserId = userId;
            Password = password;
        }
        public void ConnectTo()
        {
            if (IsConnected) throw new Exception();
            _connectionString = $"Data Source={DataSource};Initial Catalog={Catalog};User ID={UserId};Password={Password}";
            _cnn = new SqlConnection(_connectionString);
            _cnn.Open();
            IsConnected = true;
        }
        
        public void DisconnectFrom()
        {
            if (!IsConnected) throw new Exception();
            _connectionString = $"Data Source={DataSource};Initial Catalog={Catalog};User ID={UserId};Password={Password}";
            _cnn = new SqlConnection(_connectionString);
            _cnn.Close();
            IsConnected = false;
        }

        public string GetDataFrom(string tableName)
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
                output = output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }

            return output;
        }

        public void AddDataTo(string tableName, string columnsNames, string data)
        {
            if (!IsConnected) throw new Exception();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sqlString = "";

            sqlString = $"INSERT INTO {tableName} ({columnsNames}) VALUES({data})";

            command = new SqlCommand(sqlString, _cnn);

            adapter.InsertCommand = new SqlCommand(sqlString, _cnn);
            adapter.InsertCommand.ExecuteNonQuery();
            
            command.Dispose();
        }

        public void UpdateDataIn(string tableName, string updatingData, string id)
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
        
        public void DeleteDataFrom(string tableName, string id)
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
