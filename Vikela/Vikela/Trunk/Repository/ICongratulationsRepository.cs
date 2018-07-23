using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface ICongratulationsRepository<T>
        where T : BaseViewModel
    {
        Task Done(CongratulationsViewModel model, Action<T> completeAction);
    }
}
