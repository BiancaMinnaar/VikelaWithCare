using System.Collections.Generic;
using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service.Implementation;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.ViewController
{
    public class CongratulationsViewController : ProjectBaseViewController<CongratulationsViewModel>, ICongratulationsViewController
    {
        ICongratulationsRepository _Reposetory;
        IRegisterRepository RegisterRepository;
        IRegisterService RegisterService;
        IRegistrationCellphoneRepository _CellReposetory;
        INIUSSDService<NIUSSDReturnModel> nIUSSDService;

        public override void SetRepositories()
        {
            _Reposetory = new CongratulationsRepository<CongratulationsViewModel>(_MasterRepo);
            RegisterService = new RegisterService((U, P, A) =>
                                                  ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            var _DynamixService = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            var _DynamixReturnService = new DynamixReturnService<List<DynamixContact>>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<List<DynamixContact>>(U, P, A));
            var _DynamixPolicyReturnService = new DynamixReturnService<List<DynamixPolicy>>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<List<DynamixPolicy>>(U, P, A));
            var _DynamixUserReturnService = new DynamixReturnService<GetUserReturnModel>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<GetUserReturnModel>(U, P, A));
            RegisterRepository = new RegisterRepository(_MasterRepo, RegisterService, _DynamixService, _DynamixReturnService,
            null, null, _DynamixUserReturnService);
            nIUSSDService = new NIUSSDService<NIUSSDReturnModel>((U, P, A) =>
                                                             ExecuteQueryWithReturnTypeAndNetworkAccessAsync<NIUSSDReturnModel>(U, P, A));
            _CellReposetory = new RegistrationCellphoneRepository(_MasterRepo, nIUSSDService);
        }

        public async Task CompleteRegistrationAsync()
        {
            var registerData = RegisterRepository.GetDyn365RegisterViewModel();
            var checkUser = await RegisterRepository.GetUserWithOIDAsync(registerData);
            if (checkUser.data.userId == null)
            {
                var user = await RegisterRepository.RegisterWithD365Async(registerData);
                if (user != null && user.success && user.data.verified)
                    _MasterRepo.PushMyCoverView();
            }
            else if (!checkUser.data.verified)
            {
                var sendModel = new NIUSSDViewModel
                {
                    mobileNumber = registerData.MobileNumber,
                    userId = _MasterRepo.DataSource.User.UserID,
                    TokenID = _MasterRepo.DataSource.User.TokenID
                };
                await _CellReposetory.SendUSSDTestAsync(sendModel);
            }
            else
            {
                _MasterRepo.PushMyCoverView();
            }
        }

        public async Task RefreshActiveState()
        {
            var registerData = RegisterRepository.GetDyn365RegisterViewModel();
            var user = await RegisterRepository.GetUserWithOIDAsync(registerData);
            if (user != null && user.success && user.data.verified)
                _MasterRepo.PushMyCoverView();
        }

        public void Logout()
        {
            _MasterRepo.PushLogOut();
        }
    }
}