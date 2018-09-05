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
        IRegistrationEmailRepository<RegistrationEmailViewModel> _Reposetory;
        IRegistrationEmailService<RegistrationEmailViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new RegistrationEmailService<RegistrationEmailViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegistrationEmailViewModel>(U, P, C, A));
            _Reposetory = new RegistrationEmailRepository<RegistrationEmailViewModel>(_MasterRepo, _Service);
            InputObject.EmailAddress = _MasterRepo.DataSource.User.EmailAddress;
        }

        public async Task UpdateEmailAsync()
        {
            await _Reposetory.UpdateEmailAsync(InputObject);
            _MasterRepo.PushRegistrationCellphone();
        }
    }
}