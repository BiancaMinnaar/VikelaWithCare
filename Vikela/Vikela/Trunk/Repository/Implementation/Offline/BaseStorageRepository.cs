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

        protected string TableCountQuery { get; private set; }

        public BaseStorageRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
            TableCountQuery = $"SELECT count(1) FROM sqlite_master WHERE type = 'table' AND name = '{tableName}'";
            OfflineStorageRepo = OfflineStorageRepository.Instance;
        }

        private async Task<bool> CheckModelTableAsync()
        {
            return await OfflineStorageRepo.SelectScalar(
                TableCountQuery) != 0;
        }

        private async Task CreateModelTabelAsync()
        {
            await OfflineStorageRepo.CreateTable<T>();
        }

        protected async Task<bool> CheckCreateModelTable()
        {
            var exists = await CheckModelTableAsync();
            if (!exists)
            {
                await CreateModelTabelAsync();
            }
            return exists;
        }
    }
}
