using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationCellphoneRepository<T>
        where T : BaseViewModel
    {
        Task UpdateCellPhone(RegistrationCellphoneViewModel model, Action<UserModel> completeAction);
    }
}
