/*
 + CONNECTION - (Name || Data Source, Credentials, Optional parameters)
 TODO Selecting data from DB
 TODO Inserting data to DB
 TODO Updating data into DB
 TODO Deleting data from DB   
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB_Connection
{
    public class SqlConnecting
    {
        private SqlConnection _cnn;
        private string _connectionString;

        private string DataSource { get; init; }
        private string Password { get; init; }
        private string Catalog { get; init; }
        private string UserId { get; init; }
        public bool IsConnected { get; private set; }
        public SqlConnecting(string dataSource, string catalog, string password, string userId)
        {
            IsConnected = false;
            DataSource = dataSource;
            Password = password;
            Catalog = catalog;
            UserId = userId;
        }
        public void ConnectTo()
        {
            _connectionString = $"Data Source={DataSource};Initial Catalog={Catalog};User ID={UserId};Password={Password}";
            _cnn = new SqlConnection(_connectionString);
            _cnn.Open();
            IsConnected = true;
        }
        
        public void DisconnectFrom()
        {
            if (!IsConnected) return;
            _connectionString = $"Data Source={DataSource};Initial Catalog={Catalog};User ID={UserId};Password={Password}";
            _cnn = new SqlConnection(_connectionString);
            _cnn.Close();
            IsConnected = false;
        }

        public string GetDataFrom(string name)
        {
            if (!IsConnected) throw new Exception();
            SqlCommand command;
            SqlDataReader dataReader;
            String sqlString, output = "";

            sqlString = $"SELECT * FROM {name};";

            command = new SqlCommand(sqlString, _cnn);

            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                output = output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }

            return output;
        }
    }
}
