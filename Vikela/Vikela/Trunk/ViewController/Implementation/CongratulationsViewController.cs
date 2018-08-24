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
    public class CongratulationsViewController : ProjectBaseViewController<CongratulationsViewModel>, ICongratulationsViewController
    {
        ICongratulationsRepository<CongratulationsViewModel> _Reposetory;
        IRegisterRepository<RegisterViewModel> RegisterRepository;
        ICongratulationsService<CongratulationsViewModel> _Service;
        IRegisterService RegisterService;

        public override void SetRepositories()
        {
            _Service = new CongratulationsService<CongratulationsViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<CongratulationsViewModel>(U, P, C, A));
            _Reposetory = new CongratulationsRepository<CongratulationsViewModel>(_MasterRepo, _Service);
            RegisterService = new RegisterService((U, P, A) =>
                                                           ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            RegisterRepository = new RegisterRepository<RegisterViewModel>(_MasterRepo, RegisterService);
        }

        public async Task CompleteRegistrationAsync()
        {
            await RegisterRepository.RegisterWithD365Async(new RegisterViewModel()
            {
                EmailAddress = "Edit",
                FirstName = _MasterRepo.DataSource.User.FirstName,
                IDNumber = "Edit",
                LastName = "Edit",
                MobileNumber = _MasterRepo.DataSource.User.MobileNumber,
                OID = _MasterRepo.DataSource.User.OID,
                UserPictureURL = "Edit"
            });
            _MasterRepo.PushMyCoverView();
        }
    }
}