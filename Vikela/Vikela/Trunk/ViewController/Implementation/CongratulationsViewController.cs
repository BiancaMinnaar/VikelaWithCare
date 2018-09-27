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
        }

        public async Task CompleteRegistrationAsync()
        {
            _MasterRepo.ShowLoading();
            var registerData = RegisterRepository.GetDyn365RegisterViewModel();
            var user = await RegisterRepository.RegisterWithD365Async(registerData);
            _MasterRepo.HideLoading();
            //TODO: navigate on success.??
            //if (user.success)
                //_MasterRepo.PushMyCoverView();
            //{
            //    foreach (var message in errors)
                    //ShowMessage(user.success.ToString());
            //}
            //else
                //ShowMessage(_ResponseContent);
        }

        public async Task RefreshActiveState()
        {
            var registerData = RegisterRepository.GetDyn365RegisterViewModel();
            var dd = await RegisterRepository.GetUserWithOIDAsync(registerData);
            //TODO: navigate on success.
        }

        public void Logout()
        {
            _MasterRepo.PushLogOut();
        }
    }
}