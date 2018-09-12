using System.Threading.Tasks;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository
{
    public interface IContactStorageRepository
    {
		Task SaveContactToLocalStorage(ContactModel model);
		Task GetContactWithID(ContactModel model);
    }
}
