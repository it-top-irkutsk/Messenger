namespace DB_Connection
{
    public interface ISqlConnecting
    {
        public void SetDataSource(string dataSource);

        public void SetPassword(string password);

        public void SetCatalog(string catalog);

        public void SetUserId(string userId);

        public void ConnectToDb();

        public void DisconnectFromDb();

        public void ConnectToTable();

        public void DisconnectFromTable();
        
        public void GetTables();
        
        public void GetData(int id);
    }
}