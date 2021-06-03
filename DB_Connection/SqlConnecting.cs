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
        private string _connectionString, _dataSource, _password, _catalog, _userId;
        private SqlConnection _cnn;
        private static bool _isConnected;
        private ISqlConnecting _sqlConnectingImplementation;

        public void SetDataSource(string dataSource)
        {
            _dataSource = dataSource;
        }
        
        public void SetPassword(string password)
        {
            _password = password;
        }
        
        public void SetCatalog(string catalog)
        {
            _catalog = catalog;
        }
        
        public void SetUserId(string userId)
        {
            _userId = userId;
        }
        
        public void ConnectToDb()
        {
            _connectionString = $"Data Source={_dataSource};Initial Catalog={_catalog};User ID={_userId};Password={_password}";
            _cnn = new SqlConnection(_connectionString);
            _cnn.Open();
            _isConnected = true;
        }
        
        public void DisconnectFromDb()
        {
            if (!_isConnected) return;
            _connectionString = $"Data Source={_dataSource};Initial Catalog={_catalog};User ID={_userId};Password={_password}";
            _cnn = new SqlConnection(_connectionString);
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
