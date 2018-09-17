using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IAddTrustedSourceRepository
    {
        ContactDetailViewModel GetTrustedContactDetailFromMaster();
        Task SaveTrustedSourceAsync(ContactDetailViewModel model);
        Task UpdateMasterWithTrustedSourceAsync(ContactDetailViewModel model);
    }
}
