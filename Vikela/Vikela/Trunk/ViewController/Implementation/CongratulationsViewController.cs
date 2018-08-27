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
        IRegisterService<RegisterViewModel> RegisterService;

        public override void SetRepositories()
        {
            _Service = new CongratulationsService<CongratulationsViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<CongratulationsViewModel>(U, P, C, A));
            _Reposetory = new CongratulationsRepository<CongratulationsViewModel>(_MasterRepo, _Service);
            RegisterService = new RegisterService<RegisterViewModel>((U, P, C, A) =>
                                                                     ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegisterViewModel>(U, P, C, A));
            RegisterRepository = new RegisterRepository<RegisterViewModel>(_MasterRepo, RegisterService);
        }

        public async Task CompleteRegistrationAsync()
        {
            await RegisterRepository.RegisterWithD365Async(new RegisterViewModel()
            {
                UniqueIdentifier = _MasterRepo.DataSource.User.UniqueIdentifier,
                EmailAddress = "Edit@email.com",
                FirstName = _MasterRepo.DataSource.User.FirstName,
                IDNumber = "Edit",
                LastName = "Edit",
                MobileNumber = _MasterRepo.DataSource.User.MobileNumber,
                OID = _MasterRepo.DataSource.User.OID,
                UserPictureURL = "Edit",
                TokenID = _MasterRepo.DataSource.User.TokenID
            });
            _MasterRepo.PushMyCoverView();
        }
    }
}