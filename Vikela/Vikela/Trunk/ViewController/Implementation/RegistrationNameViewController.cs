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
    public class RegistrationNameViewController : ProjectBaseViewController<RegistrationNameViewModel>, IRegistrationNameViewController
    {
        IRegistrationNameRepository<RegistrationNameViewModel> _Reposetory;
        IRegistrationNameService<RegistrationNameViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new RegistrationNameService<RegistrationNameViewModel>((U, P, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegistrationNameViewModel>(U, P, A));
            _Reposetory = new RegistrationNameRepository<RegistrationNameViewModel>(_MasterRepo, _Service);
            InputObject.FirstName = _MasterRepo.DataSource.User.FirstName;
            InputObject.LastName = _MasterRepo.DataSource.User.LastName;
        }

        public async Task UpdateNameAsync()
        {
            await _Reposetory.UpdateNameAsync(InputObject);
            _MasterRepo.PushRegistrationEmailAddress();
        }
    }
}