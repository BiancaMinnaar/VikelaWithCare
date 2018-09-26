using System;
using System.Linq;
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
            var policyToView = from policy in _MasterRepo.DataSource.PurchaseHistory
                               where policy.PolicyID == policyID
                         select policy;
            InputObject = policyToView.FirstOrDefault();
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }
    }
}