using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel.Offline;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Repository.Implementation;
using Vikela.Trunk.Injection.Base;

namespace Vikela.Implementation.Repository
{
    public class RegisterRepository<T> : ProjectBaseRepository, IRegisterRepository<T>
        where T : BaseViewModel
    {
        private const string SelectTableCount = "SELECT count(1) FROM sqlite_master WHERE type = 'table' AND name = 'UserModel'";
        private const string SelectTopUser = "SELECT * FROM UserModel";
        IRegisterService<T> _Service;
        IOfflineStorageRepository OfflineStorageRepo;
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public RegisterRepository(IMasterRepository masterRepository, IRegisterService<T> service)
            : base(masterRepository)
        {
            _Service = service;
            OfflineStorageRepo = OfflineStorageRepository.Instance;

            _PlatformBonsai = new PlatformBonsai();
            var platform = new PlatformRepository<RegisterViewModel>(masterRepository, _PlatformBonsai)
            {
                OnError = (errs) =>
                {
                    OnError?.Invoke(errs);
                }
            };
        }

        public async Task Register(RegisterViewModel model, Action<UserModel> completeAction)
        {
            var serviceReturnModel = await _Service.Register(model);
            var actionModel = new UserModel()
            {
                FirstName = model.FisrtName,
                LastName = model.LastName,
                MobileNumber = model.MobileNumber,
                UserPicture = model.UserPicture
                ///TODO: Add MoreFields
            };
            await SetUserRecord(actionModel);
            completeAction(actionModel);
        }

        public void OAuthFacebook(RegisterViewModel model, Action<T> completeAction)
        {
            foreach (var service in _PlatformBonsai.GetBonsaiServices)
            {
                if (service.PlatformHarness.ServiceKey == "FacebookService")
                {
                    _MasterRepo.OnPlatformServiceCallBack.Add((serviceKey, locationM) =>
                    {
                        if (serviceKey.Equals("FacebookService"))
                        {
                            ///TODO:Implement model update
                        }
                    });
                    service.PlatformHarness.Activate();
                }
            }
        }

        public void OAuthInstagram(RegisterViewModel model, Action<T> completeAction)
        {
            throw new NotImplementedException();
        }

        public void OAuthGoogle(RegisterViewModel model, Action<T> completeAction)
        {
            throw new NotImplementedException();
        }

        private async Task SetUserRecord(UserModel model)
        {
            if (! await CheckUserModelTable())
            {
                await CreateUserModelTabel();

            }
            if (await GetUserRecord() != null)
            {
                var s = await OfflineStorageRepo.Connection.UpdateAsync(model);
            }
            else
            {
                model.Id = await OfflineStorageRepo.Connection.InsertAsync(model);
            }
        }

        public async Task<UserModel> GetUserModelFromOffline()
        {
            var hasUserModelTable = await CheckUserModelTable();
            if (hasUserModelTable)
            {
                return await GetUserRecord();
            }
            return null;
        }

        private async Task<bool> CheckUserModelTable()
        {
            return await OfflineStorageRepo.Connection.ExecuteScalarAsync<int>(
                SelectTableCount) < 1;
        }

        private async Task CreateUserModelTabel()
        {
            await OfflineStorageRepo.Connection.CreateTableAsync<UserModel>();
        }

        private async Task<UserModel> GetUserRecord()
        {
            var list = await OfflineStorageRepo.Connection.QueryAsync<UserModel>(
                SelectTopUser);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public async Task RemoveUserRecord(UserModel model)
        {
            await OfflineStorageRepo.Connection.DeleteAsync(model);
        }
    }
}