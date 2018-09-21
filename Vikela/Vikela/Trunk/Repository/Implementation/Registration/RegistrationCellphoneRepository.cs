using System.Threading.Tasks;
using CorePCL;
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

        public async Task<bool> UpdateCellPhoneWithUSSDTestAsync(RegistrationCellphoneViewModel model)
        {
            _MasterRepo.DataSource.User.MobileNumber = model.CellPhoneNumber;
            var sendModel = new NIUSSDViewModel 
            { 
                mobileNumber = model.CellPhoneNumber, 
                userId = _MasterRepo.DataSource.User.OID, 
                TokenID = _MasterRepo.DataSource.User.TokenID };
            var returnVal = await _ussdService.SendUSSDAsync(sendModel);
            if (returnVal.body.result == "Accept")
            { 
                await OfflineStorageRepository.Instance.UpdateRecordAsync(_MasterRepo.DataSource.User);
                return true;
            }
            return false;
        }
    }
}