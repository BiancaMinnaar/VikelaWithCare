using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationIDNumberRepository<T>
        where T : BaseViewModel
    {
        Task UpdateIDNumber(RegistrationIDNumberViewModel model, Action<T> completeAction);
    }
}
