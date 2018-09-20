using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IVoucherRepository
    {
        Task YourMethodName(VoucherViewModel model, Action completeAction);
    }
}
