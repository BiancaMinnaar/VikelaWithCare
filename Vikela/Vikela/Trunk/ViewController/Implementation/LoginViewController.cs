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
    public class LoginViewController : ProjectBaseViewController<LoginViewModel>, ILoginViewController
    {
        ILoginRepository<LoginViewModel> _Reposetory;
        ILoginService<LoginViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new LoginService<LoginViewModel>((U, P, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<LoginViewModel>(U, P, A));
            _Reposetory = new LoginRepository<LoginViewModel>(_MasterRepo, _Service);
        }

        public async Task Login()
        {
            //Authenticate
            //navigate
            _MasterRepo.PushMyCoverView();
            //_MasterRepo.PushEditProfile();
        }
    }
}