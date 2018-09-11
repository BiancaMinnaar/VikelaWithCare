using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class RegistrationCellphoneViewController : ProjectBaseViewController<RegistrationCellphoneViewModel>, IRegistrationCellphoneViewController
    {
        IRegistrationCellphoneRepository<RegistrationCellphoneViewModel> _Reposetory;

        public override void SetRepositories()
        {
            _Reposetory = new RegistrationCellphoneRepository<RegistrationCellphoneViewModel>(_MasterRepo);

            InputObject.Greeting = "Hi " + _MasterRepo.DataSource.User.FirstName +
                ", what is your cellphone number?";
            InputObject.CellPhoneNumber = _MasterRepo.DataSource.User.MobileNumber;
        }

        public async Task UpdateCellPhoneAsync()
        {
            await _Reposetory.UpdateCellPhoneAsync(InputObject);
            _MasterRepo.PushRegistrationOTP();
        }
    }
}