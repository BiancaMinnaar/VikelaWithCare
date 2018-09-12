using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Trunk.Service
{
    public interface IDynamixService
    {
		Task RegisterUserAsync(RegisterViewModel model);
        Task GetUserWithOIDAsync(RegisterViewModel model);
		Task AddTrustedSourceAsync(ContactDetailViewModel model);
		Task AddBeneficiaryAsync(ContactDetailViewModel model);
        Task UpdateTrustedSourceAsync(ContactDetailViewModel model);
        Task UpdateBeneficiaryAsync(ContactDetailViewModel model);
    }
}
