using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationIDNumberRepository<T>
        where T : BaseViewModel
    {
        Task UpdateIDNumber(RegistrationIDNumberViewModel model, Action<UserModel> completeAction);
    }
}
