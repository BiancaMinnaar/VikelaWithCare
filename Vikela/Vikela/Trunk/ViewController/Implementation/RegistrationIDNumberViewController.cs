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
        IRegistrationIDNumberService<RegistrationIDNumberViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new RegistrationIDNumberService<RegistrationIDNumberViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegistrationIDNumberViewModel>(U, P, C, A));
            _Reposetory = new RegistrationIDNumberRepository<RegistrationIDNumberViewModel>(_MasterRepo, _Service);
        }

        public async Task UpdateIDNumber()
        {
            await _Reposetory.UpdateIDNumber(InputObject, (ModelIO) =>
                                             _MasterRepo.PushCongratulationsView());
        }
    }
}