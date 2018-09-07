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
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Implementation.ViewController
{
    public class WelcomeViewController : ProjectBaseViewController<WelcomeViewModel>, IWelcomeViewController
    {
        IWelcomeRepository _Reposetory;
        IRegisterService _RegisterService;
        IRegisterRepository _RegisterRepo;
        ISelfieRepository<RegisterViewModel> _SelfieRepo;
        IDynamixService _DynamixService;

        public override void SetRepositories()
        {
            _RegisterService = new RegisterService((U, P, A) =>
                                                   ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _DynamixService = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _RegisterRepo = new RegisterRepository(_MasterRepo, _RegisterService, _DynamixService);
            _SelfieRepo = new SelfieRepository<RegisterViewModel>(_MasterRepo, null);
            _Reposetory = new WelcomeRepository(_MasterRepo, _RegisterRepo, _SelfieRepo);
        }

        private async Task SetUserWithD365DataAsync(RegisterViewModel model)
        {
            await _RegisterRepo.GetUserWithOIDAsync(model);
            await _RegisterRepo.SetUserWithServerData(_ResponseContent);
        }

        public async Task SetUserAsync(AuthenticationResult ar)
        {
            var authResult = new AzureAuthenticationResult() { IdToken = ar.IdToken };
            var registration = _RegisterRepo.GetUserFromARToken(authResult);
            await _RegisterRepo.CallForImageBlobStorageSASAsync(registration);
            registration.PictureStorageSASToken = _ResponseContent;
            await _RegisterRepo.SetUserRecordWithRegisterViewModelAsync(registration);
            await _Reposetory.GetUserSelfieFromStorageAsync();
            await SetUserWithD365DataAsync(registration);
            _Reposetory.RegisterOrShowProfile(_Reposetory.IsRegisteredUser(_ResponseContent));
            _MasterRepo.HideLoading();
        }
    }
}