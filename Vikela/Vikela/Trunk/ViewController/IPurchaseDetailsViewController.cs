using System;

namespace Vikela.Interface.ViewController
{
    public interface IPurchaseDetailsViewController
    {
        void SetPolicyDetailWithPolicyID(Guid policyID);
        void PopToCover();
    }
}
