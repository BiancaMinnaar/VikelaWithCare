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
    public class RegistrationVerifyMobileViewController : ProjectBaseViewController<RegistrationVerifyMobileViewModel>, IRegistrationVerifyMobileViewController
    {
        IRegistrationVerifyMobileRepository<RegistrationVerifyMobileViewModel> _Reposetory;

        public override void SetRepositories()
        {
            _Reposetory = new RegistrationVerifyMobileRepository<RegistrationVerifyMobileViewModel>(_MasterRepo);
        }

        public async Task UpdateOTPAsync()
        {
            await _Reposetory.UpdateOTPAsync(InputObject);
            _MasterRepo.PushRegistrationIDNumber();
        }
    }
}