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
        ICongratulationsService<CongratulationsViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new CongratulationsService<CongratulationsViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<CongratulationsViewModel>(U, P, C, A));
            _Reposetory = new CongratulationsRepository<CongratulationsViewModel>(_MasterRepo, _Service);
        }

        public void Done()
        {
            _MasterRepo.PushLogOut();
        }
    }
}