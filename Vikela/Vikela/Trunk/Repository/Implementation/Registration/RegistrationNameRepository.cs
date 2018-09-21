using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.Repository.Implementation;

namespace Vikela.Implementation.Repository
{
    public class RegistrationNameRepository<T> : ProjectBaseRepository, IRegistrationNameRepository<T>
        where T : BaseViewModel
    {
        public RegistrationNameRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }

        public async Task UpdateNameAsync(RegistrationNameViewModel model)
        {
            _MasterRepo.DataSource.User.FirstName = model.FirstName;
            _MasterRepo.DataSource.User.LastName = model.LastName;
            await OfflineStorageRepository.Instance.UpdateRecordAsync(_MasterRepo.DataSource.User);
        }
    }
}