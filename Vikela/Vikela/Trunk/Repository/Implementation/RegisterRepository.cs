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
using Vikela.Trunk.Injection.Base;

namespace Vikela.Implementation.Repository
{
    public class RegisterRepository<T> : ProjectBaseRepository, IRegisterRepository<T>
        where T : BaseViewModel
    {
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

        public async Task Register(RegisterViewModel model, Action<T> completeAction)
        {
            //var serviceReturnModel = await _Service.Register(model);
            //completeAction(serviceReturnModel);
            await SetUserRecord(new UserModel()
            {
                FirstName = model.FisrtName,
                LastName = model.LastName,
                MobileNumber = model.MobileNumber,
                UserPicture = model.UserPicture
            });
        }

        public async Task SetUserRecord(UserModel model)
        {
            if (!await CheckUserRecord())
            {
                await OfflineStorageRepo.Connection.CreateTableAsync<UserModel>();
                var s = await OfflineStorageRepo.Connection.InsertAsync(model);
            }
            else
            {
                var s = await OfflineStorageRepo.Connection.UpdateAsync(model);
            }
        }

        public async Task<bool> CheckUserRecord()
        {
            var returnVal = await OfflineStorageRepo.Connection.ExecuteScalarAsync<int>("SELECT count(1) FROM sqlite_master WHERE type = 'table' AND name = 'UserModel'");
            return returnVal > 0;
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
    }
}