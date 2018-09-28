using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.Repository.Implementation;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.Repository
{
    public class RegistrationCellphoneRepository : ProjectBaseRepository, IRegistrationCellphoneRepository
    {
        INIUSSDService<NIUSSDReturnModel> _ussdService;

        public RegistrationCellphoneRepository(IMasterRepository masterRepository, INIUSSDService<NIUSSDReturnModel> ussdService)
            : base(masterRepository)
        {
            _ussdService = ussdService;
        }

        public async Task UpdateCellPhoneAsync(RegistrationCellphoneViewModel model)
        {
            _MasterRepo.DataSource.User.MobileNumber = model.CellPhoneNumber;
            await OfflineStorageRepository.Instance.UpdateRecordAsync(_MasterRepo.DataSource.User);
        }

        public async Task SendUSSDTestAsync(NIUSSDViewModel model)
        {
            await _ussdService.SendUSSDAsync(model);
        }
    }
}