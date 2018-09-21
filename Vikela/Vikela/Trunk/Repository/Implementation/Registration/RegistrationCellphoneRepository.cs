using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.Repository.Implementation;

namespace Vikela.Implementation.Repository
{
    public class RegistrationCellphoneRepository : ProjectBaseRepository, IRegistrationCellphoneRepository
    {

        public RegistrationCellphoneRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }

        public async Task UpdateCellPhoneAsync(RegistrationCellphoneViewModel model)
        {
            _MasterRepo.DataSource.User.MobileNumber = model.CellPhoneNumber;
            await OfflineStorageRepository.Instance.UpdateRecordAsync(_MasterRepo.DataSource.User);
        }
    }
}