using System;
using System.IO;
using System.Threading.Tasks;
using CorePCL;
using SQLite;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel.Offline;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Repository.Implementation;

namespace Vikela.Implementation.Repository
{
    public class RegisterRepository<T> : ProjectBaseRepository, IRegisterRepository<T>
        where T : BaseViewModel
    {
        IRegisterService<T> _Service;
        IOfflineStorageRepository OfflineStorageRepo;

        public RegisterRepository(IMasterRepository masterRepository, IRegisterService<T> service)
            : base(masterRepository)
        {
            _Service = service;
            OfflineStorageRepo = OfflineStorageRepository.Instance;
        }

        public async Task Register(RegisterViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Register(model);
            completeAction(serviceReturnModel);
            await SetUserRecord(new User()
            {
                FirstName = model.FisrtName,
                LastName = model.LastName,
                MobileNumber = model.MobileNumber,
                UserPicture = model.UserPicture
            });
        }

        public async Task SetUserRecord(User model)
        {
            if (!await CheckUserRecord())
            {
                await OfflineStorageRepo.Connection.CreateTableAsync<User>();
                var s = await OfflineStorageRepo.Connection.InsertAsync(model);
            }
            else
            {
                var s = await OfflineStorageRepo.Connection.UpdateAsync(model);
            }
        }

        private async Task<bool> CheckUserRecord()
        {
            var returnVal = await OfflineStorageRepo.Connection.ExecuteScalarAsync<int>("SELECT count(1) FROM sqlite_master WHERE type = 'table' AND name = 'User'");
            return returnVal > 0;
        }
    }
}