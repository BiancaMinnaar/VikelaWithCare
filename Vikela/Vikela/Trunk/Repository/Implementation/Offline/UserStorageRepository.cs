using System.Threading.Tasks;
using Vikela.Interface.Repository;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository.Implementation.Offline
{
    public class UserStorageRepository : BaseStorageRepository<UserModel>, IUserStorageRepository
    {
        internal const string SelectTopUser = "SELECT * FROM UserModel";

        public UserStorageRepository(IMasterRepository masterRepository, IOfflineStorageRepository offlineStorageRepo)
			: base(masterRepository, offlineStorageRepo)
        {
        }

        public async Task SetUserRecordAsync(UserModel model)
        {
            var localUser = await GetUserRecordAsync();
            if (localUser != null)
            {
                model.Id = localUser.Id;
                var affected = await OfflineStorageRepo.UpdateRecordAsync(model);
                var whatIsAff = affected;
            }
            else
            {
                await OfflineStorageRepo.InsertRecordAsync(model);
            }
            _MasterRepo.DataSource.User = await GetUserModelFromOfflineAsync();
        }

        public async Task<UserModel> GetUserModelFromOfflineAsync()
        {
            return await GetUserRecordAsync();
        }

        public async Task RemoveUserRecordAsync(UserModel model)
        {
            var list = await OfflineStorageRepo.QueryTableAsync<UserModel>(
                SelectTopUser);
            foreach (var allModel in list)
            {
                await OfflineStorageRepo.DeleteRecordAsync(allModel);
            }
            _MasterRepo.InitializeDataSource();
        }

        private async Task<UserModel> GetUserRecordAsync()
        {
            var list = await OfflineStorageRepo.QueryTableAsync<UserModel>(
                SelectTopUser);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }
    }
}
