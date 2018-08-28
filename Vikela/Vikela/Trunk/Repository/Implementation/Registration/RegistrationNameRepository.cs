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
        IRegistrationNameService<T> _Service;

        public RegistrationNameRepository(IMasterRepository masterRepository, IRegistrationNameService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task UpdateNameAsync(RegistrationNameViewModel model)
        {
            _MasterRepo.DataSource.User.FirstName = model.FirstName;
            _MasterRepo.DataSource.User.LastName = model.LastName;
            _MasterRepo.DataSource.User.EmailAddress = "edit@edit.edit";
            await OfflineStorageRepository.Instance.UpdateRecord(_MasterRepo.DataSource.User);
        }
    }
}