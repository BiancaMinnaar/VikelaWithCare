using System;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class PurchaseDetailsViewController : ProjectBaseViewController<PurchaseDetailsViewModel>, IPurchaseDetailsViewController
    {
        public override void SetRepositories()
        {
        }

        public void SetPolicyDetailWithPolicyID(Guid policyID)
        {

        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }
    }
}