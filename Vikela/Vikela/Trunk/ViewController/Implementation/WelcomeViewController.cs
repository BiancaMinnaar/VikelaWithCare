using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class WelcomeViewController : ProjectBaseViewController<WelcomeViewModel>, IWelcomeViewController
    {
        IWelcomeRepository<WelcomeViewModel> _Reposetory;
        IWelcomeService<WelcomeViewModel> _Service;
        IRegisterService<RegisterViewModel> _RegisterService;
        IRegisterRepository<RegisterViewModel> _RegisterRepo;
        ISelfieRepository<RegisterViewModel> _SelfieRepo;

        public override void SetRepositories()
        {
            _Service = new WelcomeService<WelcomeViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<WelcomeViewModel>(U, P, C, A));
            _RegisterService = new RegisterService<RegisterViewModel>((U, P, C, A) =>
                                                                     ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegisterViewModel>(U, P, C, A));
            _RegisterRepo = new RegisterRepository<RegisterViewModel>(_MasterRepo, _RegisterService);
            _SelfieRepo = new SelfieRepository<RegisterViewModel>(_MasterRepo, null);
            _Reposetory = new WelcomeRepository<WelcomeViewModel>(_MasterRepo, _Service, _RegisterRepo, _SelfieRepo);
        }

        public async Task SetUserAsync(AuthenticationResult ar)
        {
            var registration = _RegisterRepo.GetUserFromARToken(ar);
            await _RegisterRepo.CallForImageBlobStorageSASAsync(registration);
            registration.PictureStorageSASToken = _ResponseContent;
            await _RegisterRepo.SetUserRecordWithRegisterViewModelAsync(registration);
            await _Reposetory.GetUserSelfieFromStorageAsync();
            _Reposetory.RegisterOrShowProfile(_Reposetory.IsRegisteredUser());
        }
    }
}