using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface ILoginRepository<T>
        where T : BaseViewModel
    {
        Task Login(LoginViewModel model, Action<T> completeAction);
    }
}
