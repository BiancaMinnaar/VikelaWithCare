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
    public class RegistrationIDNumberViewController : ProjectBaseViewController<RegistrationIDNumberViewModel>, IRegistrationIDNumberViewController
    {
        IRegistrationIDNumberRepository<RegistrationIDNumberViewModel> _Reposetory;

        public override void SetRepositories()
        {
            _Reposetory = new RegistrationIDNumberRepository<RegistrationIDNumberViewModel>(_MasterRepo);
            InputObject.IDNumber = _MasterRepo.DataSource.User.IDNumber;
        }

        public async Task UpdateIDNumberAsync()
        {
            await _Reposetory.UpdateIDNumberAsync(InputObject);
            _MasterRepo.PushRegistrationEmailAddress();
        }
    }
}