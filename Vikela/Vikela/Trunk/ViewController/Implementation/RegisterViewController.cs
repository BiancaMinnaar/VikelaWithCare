using System.Threading.Tasks;
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
    public class RegisterViewController : ProjectBaseViewController<RegisterViewModel>, IRegisterViewController
    {
        IRegisterRepository<RegisterViewModel> _Reposetory;
        IRegisterService<RegisterViewModel> _Service;
        IDynamixService _DynamixService;

        public override void SetRepositories()
        {
            _Service = new RegisterService<RegisterViewModel>((U, P, C, A) =>
                                                                     ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegisterViewModel>(U, P, C, A));
            _Reposetory = new RegisterRepository<RegisterViewModel>(_MasterRepo, _Service);
        }

        public async Task RegisterAsync()
        {
            await _Reposetory.SetUserRecordWithRegisterViewModelAsync(InputObject);
            _MasterRepo.PushSelfieView();
        }

        public void OAuthFacebook()
        {
            _Reposetory.OAuthFacebook(InputObject, null);
        }

        public void OAuthInstagram()
        {
            _Reposetory.OAuthFacebook(InputObject, null);
        }

        public void OAuthGoogle()
        {
            _Reposetory.OAuthFacebook(InputObject, null);
        }
    }
}