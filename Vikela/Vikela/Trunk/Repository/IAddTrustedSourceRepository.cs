using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IAddTrustedSourceRepository
    {
        ContactDetailViewModel GetTrustedContactDetailFromMaster();
		Task SaveTrustedContactAsync(ContactDetailViewModel model);
        ContactDetailViewModel GetDefaultBeneniciaryFromMaster();
        Task SaveDefaultBeneficiary(ContactDetailViewModel model);
        Task UpdateMasterWithTrustedSource(ContactDetailViewModel model);
        Task UpdateMasterWithBeneficiary(ContactDetailViewModel model);
    }
}
