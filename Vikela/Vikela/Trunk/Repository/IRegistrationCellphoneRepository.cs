using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationCellphoneRepository
    {
        Task<bool> UpdateCellPhoneWithUSSDTestAsync(RegistrationCellphoneViewModel model);
    }
}
