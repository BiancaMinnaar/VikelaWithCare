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
    public class RegisterViewController : ProjectBaseViewController<RegisterViewModel>, IRegisterViewController
    {
        IRegisterRepository<RegisterViewModel> _Reposetory;
        IRegisterService _Service;

        public override void SetRepositories()
        {
            _Service = new RegisterService((U, P, A) => 
                                           ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _Reposetory = new RegisterRepository<RegisterViewModel>(_MasterRepo, _Service);
        }

        public async Task RegisterAsync()
        {
            await _Reposetory.SetUserRecordWithRegisterViewModelAsync(InputObject);
            await _Reposetory.RegisterWithD365Async(new RegisterViewModel()
            {
                EmailAddress = "Edit",
                FirstName = _MasterRepo.DataSource.User.FirstName,
                IDNumber = "Edit",
                LastName = "Edit",
                MobileNumber = _MasterRepo.DataSource.User.MobileNumber,
                OID = _MasterRepo.DataSource.User.OID,
                UserPictureURL = "Edit"
            });
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