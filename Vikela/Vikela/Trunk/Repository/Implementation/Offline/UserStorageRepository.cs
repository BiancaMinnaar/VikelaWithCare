using System;
using System.Threading.Tasks;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository.Implementation.Offline
{
    public class UserStorageRepository : ProjectBaseRepository, IUserStorageRepository
    {
        private IOfflineStorageRepository OfflineStorageRepo;
        private const string SelectTableCount = "SELECT count(1) FROM sqlite_master WHERE type = 'table' AND name = 'UserModel'";
        private const string SelectTopUser = "SELECT * FROM UserModel";

        public UserStorageRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
            Task.Run(async () =>
            {
                OfflineStorageRepo = OfflineStorageRepository.Instance;
                _MasterRepo.DataSource.User = await GetUserModelFromOfflineAsync();
            });
        }

        public async Task SetUserRecordAsync(UserModel model)
        {
            if (!await CheckUserModelTableAsync())
            {
                await CreateUserModelTabelAsync();

            }
            var localUser = await GetUserRecordAsync();
            if (localUser != null)
            {
                model.Id = localUser.Id;
                var affected = await OfflineStorageRepo.UpdateRecord(model);
                var whatIsAff = affected;
            }
            else
            {
                await OfflineStorageRepo.InsertRecord(model);
            }
            _MasterRepo.DataSource.User = await GetUserModelFromOfflineAsync();
        }

        public async Task<UserModel> GetUserModelFromOfflineAsync()
        {
            var hasUserModelTable = await CheckUserModelTableAsync();

            if (hasUserModelTable)
            {
                return await GetUserRecordAsync();
            }
            else
            {
                await CreateUserModelTabelAsync();
                return null;
            }
        }

        private async Task<bool> CheckUserModelTableAsync()
        {
            return await OfflineStorageRepo.SelectScalar(
                SelectTableCount) != 0;
        }

        private async Task CreateUserModelTabelAsync()
        {
            await OfflineStorageRepo.CreateTable<UserModel>();
        }

        private async Task<UserModel> GetUserRecordAsync()
        {
            var list = await OfflineStorageRepo.QueryTable<UserModel>(
                SelectTopUser);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public async Task RemoveUserRecordAsync(UserModel model)
        {
            var list = await OfflineStorageRepo.QueryTable<UserModel>(
                SelectTopUser);
            foreach(var allModel in list)
            {
                await OfflineStorageRepo.DeleteRecord(allModel);
            }
        }
    }
}
