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
        IRegisterRepository _Reposetory;
        IRegisterService _Service;
        IDynamixService _DynamixService;

        public override void SetRepositories()
        {
            _Service = new RegisterService((U, P, A) =>
                                                                     ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _Reposetory = new RegisterRepository(_MasterRepo, _Service);
        }

        public async Task RegisterAsync()
        {
            await _Reposetory.SetUserRecordWithRegisterViewModelAsync(InputObject);
            _MasterRepo.PushSelfieView();
        }

        public void OAuthFacebook()
        {
            _Reposetory.OAuthFacebook(InputObject);
        }

        public void OAuthInstagram()
        {
            _Reposetory.OAuthFacebook(InputObject);
        }

        public void OAuthGoogle()
        {
            _Reposetory.OAuthFacebook(InputObject);
        }
    }
}