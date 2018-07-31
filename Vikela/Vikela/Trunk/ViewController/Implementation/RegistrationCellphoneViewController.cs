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
        IRegistrationCellphoneService<RegistrationCellphoneViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new RegistrationCellphoneService<RegistrationCellphoneViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegistrationCellphoneViewModel>(U, P, C, A));
            _Reposetory = new RegistrationCellphoneRepository<RegistrationCellphoneViewModel>(_MasterRepo, _Service);
        }

        public async Task UpdateCellPhone()
        {
            
        }
    }
}