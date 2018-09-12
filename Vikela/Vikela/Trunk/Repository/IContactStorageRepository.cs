using System.Collections.Generic;
using System.Threading.Tasks;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository
{
    public interface IContactStorageRepository
    {
		Task SaveContactToLocalStorageAsync(ContactModel model);
        Task SaveContactListToLocalStorageAsync(List<ContactModel> modelList);
        Task<ContactModel> GetContactWithIDAsync(ContactModel model);
        Task<List<ContactModel>> GetTrustedSourcesAsync();
        Task<ContactModel> GetDefaultBeneficiaryAsync();
    }
}
