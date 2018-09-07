using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Trunk.Service
{
    public interface IDynamixService
    {
		Task RegisterUserAsync(RegisterViewModel model);
        Task GetUserWithOIDAsync(RegisterViewModel model);
		Task AddTrustedSourceAsync(AddContactViewModel model);
		Task AddBeneficiaryAsync(AddContactViewModel model);
        Task GetConnectedContacts(RegisterViewModel model);
    }
}
