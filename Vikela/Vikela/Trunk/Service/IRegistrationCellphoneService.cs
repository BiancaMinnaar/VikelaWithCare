using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IRegistrationCellphoneService<T>
        where T : BaseViewModel
    {
        Task<T> UpdateCellPhone(RegistrationCellphoneViewModel model);
    }
}

