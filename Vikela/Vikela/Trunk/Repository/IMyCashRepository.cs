using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IMyCashRepository
    {
        Task YourMethodName(MyCashViewModel model, Action completeAction);
    }
}
