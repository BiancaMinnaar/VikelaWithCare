using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IAddTrustedSourceRepository
    {
        ContactDetailViewModel GetTrustedContactDetailFromMaster();
        ContactDetailViewModel GetDefaultBeneniciaryFromMaster();
        void UpdateMasterWithTrustedSource(ContactDetailViewModel model);
		void UpdateMasterWithBeneficiary(ContactDetailViewModel model);
    }
}
