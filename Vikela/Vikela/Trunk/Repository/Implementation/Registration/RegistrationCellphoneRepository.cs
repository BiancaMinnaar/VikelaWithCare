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
    public class RegistrationCellphoneRepository<T> : ProjectBaseRepository, IRegistrationCellphoneRepository<T>
        where T : BaseViewModel
    {
        IRegistrationCellphoneService<T> _Service;

        public RegistrationCellphoneRepository(IMasterRepository masterRepository, IRegistrationCellphoneService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task UpdateCellPhone(RegistrationCellphoneViewModel model, Action<UserModel> completeAction)
        {
            _MasterRepo.DataSource.User.MobileNumber = model.CellPhoneNumber;
            await OfflineStorageRepository.Instance.UpdateRecord(_MasterRepo.DataSource.User);
            completeAction(_MasterRepo.DataSource.User);
        }
    }
}