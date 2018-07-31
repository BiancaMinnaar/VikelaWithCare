using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationCellphoneRepository<T>
        where T : BaseViewModel
    {
        Task UpdateCellPhone(RegistrationCellphoneViewModel model, Action<T> completeAction);
    }
}
