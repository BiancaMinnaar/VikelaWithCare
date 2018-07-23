using System;
using System.IO;
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
    }
}
