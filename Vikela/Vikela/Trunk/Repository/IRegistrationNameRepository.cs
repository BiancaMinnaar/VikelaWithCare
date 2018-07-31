using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationNameRepository<T>
        where T : BaseViewModel
    {
        Task UpdateName(RegistrationNameViewModel model, Action<UserModel> completeAction);
    }
}
