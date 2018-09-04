using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.Implementation;

namespace Vikela.Implementation.ViewController
{
    public class WelcomeViewController : ProjectBaseViewController<WelcomeViewModel>, IWelcomeViewController
    {
        IWelcomeRepository _Reposetory;
        IRegisterService<RegisterViewModel> _RegisterService;
        IRegisterRepository<RegisterViewModel> _RegisterRepo;
        ISelfieRepository<RegisterViewModel> _SelfieRepo;
        IDynamixService _DynamixService;

        public override void SetRepositories()
        {
            _RegisterService = new RegisterService<RegisterViewModel>((U, P, C, A) =>
                                                                     ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegisterViewModel>(U, P, C, A));
            _DynamixService = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _RegisterRepo = new RegisterRepository<RegisterViewModel>(_MasterRepo, _RegisterService, _DynamixService);
            _SelfieRepo = new SelfieRepository<RegisterViewModel>(_MasterRepo, null);
            _Reposetory = new WelcomeRepository(_MasterRepo, _RegisterRepo, _SelfieRepo);
        }

        public async Task SetUserAsync(AuthenticationResult ar)
        {
            var registration = _RegisterRepo.GetUserFromARToken(ar);
            await _RegisterRepo.CallForImageBlobStorageSASAsync(registration);
            registration.PictureStorageSASToken = _ResponseContent;
            await _RegisterRepo.SetUserRecordWithRegisterViewModelAsync(registration);
            await _Reposetory.GetUserSelfieFromStorageAsync();
            await SetUserWithD365DataAsync(registration);
            _Reposetory.RegisterOrShowProfile(_Reposetory.IsRegisteredUser(_ResponseContent, true));
            _MasterRepo.HideLoading();
        }

        private async Task SetUserWithD365DataAsync(RegisterViewModel model)
        {
            await _RegisterRepo.GetUserWithOIDAsync(model);
            if (!HasErrors)
            {
                var user = _ResponseContent;
            }
        }
    }
}