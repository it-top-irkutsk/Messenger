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
    public class SqlConnecting : ISqlConnecting
    {
        private string ConnectionString { get; set; }
        private string DataSource { get; set; }
        private string Password { get; set; }
        private string Catalog { get; set; }
        private string UserId { get; set; }
        private SqlConnection _cnn;
        private static bool _isConnected;

        public void SetDataSource(string dataSource)
        {
            DataSource = dataSource;
        }
        
        public void SetPassword(string password)
        {
            Password = password;
        }
        
        public void SetCatalog(string catalog)
        {
            Catalog = catalog;
        }
        
        public void SetUserId(string userId)
        {
            UserId = userId;
        }
        
        public void ConnectToDb()
        {
            ConnectionString = $"Data Source={DataSource};Initial Catalog={Catalog};User ID={UserId};Password={Password}";
            _cnn = new SqlConnection(ConnectionString);
            _cnn.Open();
            _isConnected = true;
        }
        
        public void DisconnectFromDb()
        {
            if (!_isConnected) return;
            ConnectionString = $"Data Source={DataSource};Initial Catalog={Catalog};User ID={UserId};Password={Password}";
            _cnn = new SqlConnection(ConnectionString);
            _cnn.Close();
            _isConnected = false;
        }

        public void ConnectToTable()
        {
            throw new NotImplementedException();
        }

        public void DisconnectFromTable()
        {
            throw new NotImplementedException();
        }

        public void GetTables()
        {
            if (!_isConnected) return;
        }
        
        public void GetData( int id)
        {
            if (!_isConnected) return;
        }
    }
}
