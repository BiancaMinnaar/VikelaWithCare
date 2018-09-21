using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class RegistrationNameViewController : ProjectBaseViewController<RegistrationNameViewModel>, IRegistrationNameViewController
    {
        IRegistrationNameRepository<RegistrationNameViewModel> _Reposetory;

        public override void SetRepositories()
        {
            _Reposetory = new RegistrationNameRepository<RegistrationNameViewModel>(_MasterRepo);
            InputObject.FirstName = _MasterRepo.DataSource.User.FirstName;
            InputObject.LastName = _MasterRepo.DataSource.User.LastName;
        }

        public async Task UpdateNameAsync()
        {
            await _Reposetory.UpdateNameAsync(InputObject);
            _MasterRepo.PushRegistrationCellphone();
        }
    }
}