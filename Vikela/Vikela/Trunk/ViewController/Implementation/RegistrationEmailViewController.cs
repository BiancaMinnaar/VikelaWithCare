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
    public class RegistrationEmailViewController : ProjectBaseViewController<RegistrationEmailViewModel>, IRegistrationEmailViewController
    {
        IRegistrationEmailRepository _Reposetory;

        public override void SetRepositories()
        {
            _Reposetory = new RegistrationEmailRepository<RegistrationEmailViewModel>(_MasterRepo);
            InputObject.EmailAddress = _MasterRepo.DataSource.User.EmailAddress;
        }

        public async Task UpdateEmailAsync()
        {
            await _Reposetory.UpdateEmailAsync(InputObject);
            _MasterRepo.PushRegistrationCellphone();
        }
    }
}