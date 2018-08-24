using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel.Offline;
using Vikela.Trunk.Repository.Implementation;
using Vikela.Trunk.Injection.Base;

namespace Vikela.Implementation.Repository
{
    public class RegisterRepository<T> : ProjectBaseRepository, IRegisterRepository<T>
        where T : BaseViewModel
    {
        IRegisterService _Service;
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public RegisterRepository(IMasterRepository masterRepository, IRegisterService service)
            : base(masterRepository)
        {
            _Service = service;
            _PlatformBonsai = new PlatformBonsai();
            var platform = new PlatformRepository<RegisterViewModel>(masterRepository, _PlatformBonsai)
            {
                OnError = (errs) =>
                {
                    OnError?.Invoke(errs);
                }
            };
        }

        public async Task SetPictureStorageSasTokenAsync(RegisterViewModel model, string sasToken)
        {
            model.PictureStorageSASToken = sasToken;
            await SetUserRecordWithRegisterViewModelAsync(model);
        }

        public async Task SetUserRecordWithRegisterViewModelAsync(RegisterViewModel model)
        {
            var actionModel = new UserModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MobileNumber = model.MobileNumber,
                OID = model.OID,
                UserPicture = model.UserPicture,
                TokenID = model.TokenID,
                PictureStorageSASToken = model.PictureStorageSASToken
            };
            await _MasterRepo.SetUserRecord(actionModel);
        }

        public async Task SetUserRecordWithRegisterViewModelAsync(UserModel model)
        {
            await _MasterRepo.SetUserRecord(model);
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

        public async Task CallForImageBlobStorageSASAsync(RegisterViewModel model, Action completeAction)
        {
            await _Service.RegisterForSASAsync(model);
            completeAction?.Invoke();
        }

        public async Task RegisterWithD365Async(RegisterViewModel model)
        {
            await _Service.Register365UserAsync(model);
        }
    }
}