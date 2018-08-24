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
        IRegisterService _RegisterService;
        IRegisterRepository<RegisterViewModel> _RegisterRepo;
        ISelfieRepository<RegisterViewModel> _SelfieRepo;

        public override void SetRepositories()
        {
            _Service = new WelcomeService<WelcomeViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<WelcomeViewModel>(U, P, C, A));
            _RegisterService = new RegisterService ((U, P, A) =>
                                                    ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _Reposetory = new WelcomeRepository<WelcomeViewModel>(_MasterRepo, _Service, _RegisterRepo, _SelfieRepo);
            _RegisterRepo = new RegisterRepository<RegisterViewModel>(_MasterRepo, _RegisterService);
            _SelfieRepo = new SelfieRepository<RegisterViewModel>(_MasterRepo, null);
        }

        public async Task SetUserAsync(AuthenticationResult ar)
        {
            //TODO:Refactor

            //Get User from ARToken
            var registration = _Reposetory.GetUserFromARToken(ar);
            //SetAzureCredentials
            await _Reposetory.SetAzureCredentialsAsync(registration, _ResponseContent);

            //TODO:Check if User Image exist.
            //GetUserSelfieFromStorage
            await _Reposetory.GetUserSelfieFromStorageAsync();
            //TODO:Check if 365 has user
            //RegisterUser
            await _Reposetory.RegisterUserOn365Async(registration);

            //Register or showProfile
            _Reposetory.RegisterOrShowProfile(_Reposetory.IsUserImageOnLocalStorage());
        }
    }
}