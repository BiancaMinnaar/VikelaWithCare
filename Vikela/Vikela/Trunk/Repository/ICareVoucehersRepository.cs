using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface ICareVoucehersRepository
    {
        Task YourMethodName(CareVoucehersViewModel model, Action completeAction);
    }
}
