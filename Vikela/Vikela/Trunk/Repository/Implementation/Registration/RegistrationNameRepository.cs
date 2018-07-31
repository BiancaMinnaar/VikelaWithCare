using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.Repository.Implementation;
using Vikela.Trunk.ViewModel.Offline;

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

        public async Task UpdateName(RegistrationNameViewModel model, Action<UserModel> completeAction)
        {
            _MasterRepo.DataSource.User.FirstName = model.FirstName;
            await OfflineStorageRepository.Instance.UpdateRecord(_MasterRepo.DataSource.User);
            completeAction(_MasterRepo.DataSource.User);
        }
    }
}