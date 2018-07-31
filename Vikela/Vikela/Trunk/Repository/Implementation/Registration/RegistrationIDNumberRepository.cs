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
    public class RegistrationIDNumberRepository<T> : ProjectBaseRepository, IRegistrationIDNumberRepository<T>
        where T : BaseViewModel
    {
        IRegistrationIDNumberService<T> _Service;

        public RegistrationIDNumberRepository(IMasterRepository masterRepository, IRegistrationIDNumberService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task UpdateIDNumber(RegistrationIDNumberViewModel model, Action<UserModel> completeAction)
        {
            _MasterRepo.DataSource.User.IDNumber = model.IDNumber;
            await OfflineStorageRepository.Instance.UpdateRecord(_MasterRepo.DataSource.User);
            completeAction(_MasterRepo.DataSource.User);
        }
    }
}