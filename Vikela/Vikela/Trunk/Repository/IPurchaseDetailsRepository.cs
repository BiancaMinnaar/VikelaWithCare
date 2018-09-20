using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IPurchaseDetailsRepository
    {
        Task YourMethodName(PurchaseDetailsViewModel model, Action completeAction);
    }
}
