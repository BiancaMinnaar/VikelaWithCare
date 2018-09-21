using System.Threading.Tasks;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;

namespace Vikela.Trunk.Repository.Implementation.Offline
{
    public class BaseStorageRepository<T> : ProjectBaseRepository
        where T:new()
    {
        internal string tableName = typeof(T).Name;
        protected IOfflineStorageRepository OfflineStorageRepo;
        internal bool Exists { get; set; }

        protected string TableCountQuery { get; private set; }

        public BaseStorageRepository(IMasterRepository masterRepository, IOfflineStorageRepository offlineStorageRepo)
            : base(masterRepository)
        {
			OfflineStorageRepo = offlineStorageRepo;
            Task.Run(async () => Exists = await CheckCreateModelTableAsync());
            TableCountQuery = $"SELECT count(1) FROM sqlite_master WHERE type = 'table' AND name = '{tableName}'";
        }

        internal async Task<bool> CheckModelTableAsync()
        {
            return await OfflineStorageRepo.SelectScalarAsync(
                TableCountQuery) != 0;
        }

        internal async Task CreateModelTabelAsync()
        {
            if (!Exists)
                await OfflineStorageRepo.CreateTableAsync<T>();
        }

        internal async Task<bool> CheckCreateModelTableAsync()
        {
            if (!Exists)
            {
                await CreateModelTabelAsync();
            }
            return Exists;
        }
    }
}
