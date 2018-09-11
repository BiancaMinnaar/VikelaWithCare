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
        void UpdateMasterWithTrustedSource(ContactDetailViewModel model);
		void UpdateMasterWithBeneficiary(ContactDetailViewModel model);
    }
}
