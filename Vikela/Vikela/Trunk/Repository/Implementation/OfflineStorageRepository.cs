using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace Vikela.Trunk.Repository.Implementation
{
    public class OfflineStorageRepository : IOfflineStorageRepository
    {
        private static OfflineStorageRepository instance;
        private string databasePath;
        private SQLiteAsyncConnection asyncConnection;

        private OfflineStorageRepository() 
        { 
            databasePath = 
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
            asyncConnection = new SQLiteAsyncConnection(databasePath);
        }

        public static OfflineStorageRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OfflineStorageRepository();
                }
                return instance;
            }
        }

        public SQLiteAsyncConnection Connection
        {
            get { return instance.asyncConnection; }
        }

        public Task<CreateTablesResult> CreateTable<T>() where T:new()
        {
            return Connection.CreateTableAsync<T>();
        }

        public Task<int> InsertRecord(object model)
        {
            return Connection.InsertAsync(model);
        }

        public Task<int> UpdateRecord(object model)
        {
            return Connection.UpdateAsync(model);
        }

        public Task<int> DeleteRecord(object model)
        {
            return Connection.DeleteAsync(model);
        }

        public Task<int> SelectScalar(string sql, params object[] args)
        {
            return Connection.ExecuteScalarAsync<int>(sql, args);
        }

        public Task<List<T>> QueryTable<T>(string sql, params object[] args) where T : new()
        {
            return Connection.QueryAsync<T>(sql, args);
        }
    }
}
