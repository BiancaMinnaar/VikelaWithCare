using System.Threading.Tasks;
using Vikela.Interface.Repository;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository.Implementation.Offline
{
    public class ContactStorageRepository : BaseStorageRepository<ContactModel>, IUserStorageRepository
    {
        public ContactStorageRepository(IMasterRepository masterRepository, IOfflineStorageRepository offlineStorageRepo)
            : base(masterRepository, offlineStorageRepo)
        {
        }
    }
}
