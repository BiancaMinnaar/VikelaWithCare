using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service.Implementation;

namespace Vikela.Implementation.ViewController
{
    public class CongratulationsViewController : ProjectBaseViewController<CongratulationsViewModel>, ICongratulationsViewController
    {
        ICongratulationsRepository<CongratulationsViewModel> _Reposetory;
        IRegisterRepository<RegisterViewModel> RegisterRepository;
        ICongratulationsService<CongratulationsViewModel> _Service;
        IRegisterService<RegisterViewModel> RegisterService;

        public override void SetRepositories()
        {
            _Service = new CongratulationsService<CongratulationsViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<CongratulationsViewModel>(U, P, C, A));
            _Reposetory = new CongratulationsRepository<CongratulationsViewModel>(_MasterRepo, _Service);
            RegisterService = new RegisterService<RegisterViewModel>((U, P, C, A) =>
                                                                     ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegisterViewModel>(U, P, C, A));
            var _DynamixService = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            RegisterRepository = new RegisterRepository<RegisterViewModel>(_MasterRepo, RegisterService, _DynamixService);
        }

        public async Task CompleteRegistrationAsync()
        {
            var registerData = new RegisterViewModel
            {
                EmailAddress = _MasterRepo.DataSource.User.EmailAddress,
                FirstName = _MasterRepo.DataSource.User.FirstName,
                IDNumber = _MasterRepo.DataSource.User.IDNumber,
                LastName = _MasterRepo.DataSource.User.LastName,
                MobileNumber = _MasterRepo.DataSource.User.MobileNumber,
                OID = _MasterRepo.DataSource.User.OID,
                UserPictureURL = "Edit",
                TokenID = _MasterRepo.DataSource.User.TokenID
            };
            var errors = await RegisterRepository.RegisterWithD365Async(registerData);
            if (errors[0] != "Success")
            {
                foreach (var message in errors)
                    ShowMessage(message);
            }
            else
                //ShowMessage(_ResponseContent);
                _MasterRepo.PushMyCoverView();
        }
    }
}