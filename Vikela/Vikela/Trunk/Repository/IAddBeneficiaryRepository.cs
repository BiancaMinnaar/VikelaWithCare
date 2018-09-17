using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Trunk.Repository
{
    public interface IAddBeneficiaryRepository
    {
        ContactDetailViewModel GetDefaultBeneniciaryFromMaster();
        Task SaveDefaultBeneficiaryAsync(ContactDetailViewModel model);
        Task UpdateMasterWithBeneficiaryAsync(ContactDetailViewModel model);
    }
}
