using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IRegisterRepository<T>
        where T : BaseViewModel
    {
        Task Register(RegisterViewModel model, Action<T> completeAction);
        Task<bool> CheckUserRecord();
    }
}
