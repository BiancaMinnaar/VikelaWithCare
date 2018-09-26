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
            var policyToView = from policy in _MasterRepo.DataSource.PolicyList
                         where policy.PolicyID == policyID
                         select new PurchaseDetailsViewModel
                         {
                             PurchasedAt = policy.storeName,
                             Product = policy.name,
                             StartDate = policy.startDate,
                             EndDate = policy.endDate,
                             Cover = policy.ensuredAmount,
                             Premium = policy.premiumAmount
                         };
            InputObject = policyToView.FirstOrDefault();
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }
    }
}