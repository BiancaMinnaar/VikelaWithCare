using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IAddTrustedSourceRepository
    {
        ContactDetailViewModel GetTrustedContactDetailFromMaster();
		Task SaveTrustedContactAsync(ContactDetailViewModel model);
        ContactDetailViewModel GetDefaultBeneniciaryFromMaster();
        Task SaveDefaultBeneficiaryAsync(ContactDetailViewModel model);
        Task UpdateMasterWithTrustedSourceAsync(ContactDetailViewModel model);
        Task UpdateMasterWithBeneficiaryAsync(ContactDetailViewModel model);
    }
}
