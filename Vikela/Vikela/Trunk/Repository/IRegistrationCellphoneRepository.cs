using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationCellphoneRepository
    {
        Task UpdateCellPhoneAsync(RegistrationCellphoneViewModel model);
    }
}
