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
using Vikela.Trunk.Service;

namespace Vikela.Implementation.Repository
{
    public class RegisterRepository<T> : ProjectBaseRepository, IRegisterRepository<T>
        where T : BaseViewModel
    {
        IRegisterService<RegisterViewModel> _Service;
        IDynamixService _DynamixService;
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public RegisterRepository(IMasterRepository masterRepository, IRegisterService<RegisterViewModel> service, IDynamixService dynamix=null)
            : base(masterRepository)
        {
            _Service = service;
            _DynamixService = dynamix;
            _PlatformBonsai = new PlatformBonsai();
            var platform = new PlatformRepository<RegisterViewModel>(masterRepository, _PlatformBonsai)
            {
                OnError = (errs) =>
                {
                    OnError?.Invoke(errs);
                }
            };
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
            await _MasterRepo.SetUserRecordAsync(actionModel);
        }

        public async Task SetUserRecordWithRegisterViewModelAsync(UserModel model)
        {
            await _MasterRepo.SetUserRecordAsync(model);
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

        public async Task CallForImageBlobStorageSASAsync(RegisterViewModel model)
        {
            await _Service.RegisterForSASAsync(model);
        }

        public async Task RegisterWithD365Async(RegisterViewModel model)
        {
            if (_DynamixService != null)
                await _DynamixService.RegisterUserAsync(model);
        }
    }
}