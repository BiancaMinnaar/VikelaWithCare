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
            _Service = new RegistrationNameService<RegistrationNameViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegistrationNameViewModel>(U, P, C, A));
            _Reposetory = new RegistrationNameRepository<RegistrationNameViewModel>(_MasterRepo, _Service);
        }

        public async Task UpdateName()
        {
            await _Reposetory.UpdateName(InputObject, 
                                         (ModelIO) => _MasterRepo.PushRegistrationCellphone());
        }
    }
}