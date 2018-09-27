using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Trunk.Service
{
    public interface IDynamixReturnService<T>
    {
        Task<T> GetUserWithOIDAsync(RegisterViewModel model);
        Task<T> RegisterUserAsync(RegisterViewModel model);
        Task<T> GetConnectedContactsAsync(RegisterViewModel model);
        Task<T> GetAllActivePoliciesAsync(RegisterViewModel model);
        Task<T> GetCommunityAsync(RegisterViewModel model);
        Task<T> AddTrustedSourceAsync(ContactDetailViewModel model);
        Task<T> AddBeneficiaryAsync(ContactDetailViewModel model);
        Task<T> UpdateContactAsync(ContactDetailViewModel model);
    }
}
