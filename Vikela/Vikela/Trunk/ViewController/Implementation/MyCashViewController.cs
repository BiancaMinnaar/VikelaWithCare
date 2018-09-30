using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class MyCashViewController : ProjectBaseViewController<MyCashViewModel>, IMyCashViewController
    {
        IMyCashRepository _Reposetory;
        IMyCashService _Service;

        public override void SetRepositories()
        {
            _Service = new MyCashService((U, C, A) => 
                                        ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, C, A));
            _Reposetory = new MyCashRepository(_MasterRepo, _Service);
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }

        public void PushVoucherDetail()
        {
            _MasterRepo.PushVoucherView();
        }
    }
}