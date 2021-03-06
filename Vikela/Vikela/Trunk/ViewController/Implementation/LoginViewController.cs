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
        public override void SetRepositories()
        {
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