using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface INotifyClaimRepository
    {
        Task YourMethodName(NotifyClaimViewModel model, Action completeAction);
    }
}
