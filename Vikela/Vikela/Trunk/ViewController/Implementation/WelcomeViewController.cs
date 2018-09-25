using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.Implementation;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.Service.ReturnModel;
using System.Collections.Generic;

namespace Vikela.Implementation.ViewController
{
    public class WelcomeViewController : ProjectBaseViewController<WelcomeViewModel>, IWelcomeViewController
    {
        IWelcomeRepository _Reposetory;
        IRegisterService _RegisterService;
        IRegisterRepository _RegisterRepo;
        ISelfieRepository _SelfieRepo;
        IDynamixService _DynamixService;

        public override void SetRepositories()
        {
            _RegisterService = new RegisterService((U, P, A) =>
                                                   ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _DynamixService = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            var _DynamixReturnService = new DynamixReturnService<List<DynamixContact>>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<List<DynamixContact>>(U, P, A));
            var _DynamixPolicyReturnService = new DynamixReturnService<DynamixPolicy>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<DynamixPolicy>(U, P, A));
            var _DynamixCommunityReturnService = new DynamixReturnService<DynamixCommunity>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<DynamixCommunity>(U, P, A));
            _RegisterRepo = new RegisterRepository(_MasterRepo, _RegisterService, _DynamixService, _DynamixReturnService, 
			                                       _DynamixPolicyReturnService, _DynamixCommunityReturnService);
            _SelfieRepo = new SelfieRepository(_MasterRepo);
            _Reposetory = new WelcomeRepository(_MasterRepo, _RegisterRepo, _SelfieRepo);
        }

        private async Task<bool> SetUserWithD365DataAsync(RegisterViewModel model)
        {
            MustShowError = false;
            await _RegisterRepo.GetUserWithOIDAsync(model);
            MustShowError = true;
            if (_ResponseContent != "")
            {
                await _RegisterRepo.SetUserWithServerDataAsync(_ResponseContent);
                model.UserID = _MasterRepo.DataSource.User.UserID;
                return true;
            }
            return false;
        }

        public async Task SetUserAsync(AuthenticationResult ar)
        {
            _MasterRepo.ShowLoading();
            var authResult = new AzureAuthenticationResult() { IdToken = ar.IdToken };
            var registration = _RegisterRepo.GetUserFromARToken(authResult);
            await _RegisterRepo.CallForImageBlobStorageSASAsync(registration);
            registration.PictureStorageSASToken = _ResponseContent;
            await _RegisterRepo.SetUserRecordWithRegisterViewModelAsync(registration);
            await _Reposetory.GetUserSelfieFromStorageAsync();

            if (await SetUserWithD365DataAsync(registration))
            {
                await _RegisterRepo.SetUserContactsFromServerAsync(registration);
                await _RegisterRepo.SetUserPoliciesFromServerAsync(registration);
                await _RegisterRepo.SetCommunityValueFromServiceAsync(registration);
            }
            _Reposetory.RegisterOrShowProfile(_Reposetory.IsRegisteredUser(_ResponseContent));
            _MasterRepo.HideLoading();
        }
    }
}