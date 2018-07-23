using System.Threading.Tasks;
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
        IRegisterRepository<RegisterViewModel> _RegistratioRepo;

        public override void SetRepositories()
        {
            _Service = new WelcomeService<WelcomeViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<WelcomeViewModel>(U, P, C, A));
            _Reposetory = new WelcomeRepository<WelcomeViewModel>(_MasterRepo, _Service);
            _RegistratioRepo = new RegisterRepository<RegisterViewModel>(_MasterRepo, null);
        }

        public async Task Load()
        {
            var isRegistered = await _RegistratioRepo.CheckUserRecord();
            if (isRegistered)
            {
                _MasterRepo.PushLoginView();
            }
            else
            {
                _MasterRepo.PushRegistrationView();
            }
        }
    }
}