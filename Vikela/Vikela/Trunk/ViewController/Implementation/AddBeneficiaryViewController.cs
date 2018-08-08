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
    public class AddBeneficiaryViewController : ProjectBaseViewController<AddBeneficiaryViewModel>, IAddBeneficiaryViewController
    {
        IAddBeneficiaryRepository<AddBeneficiaryViewModel> _Reposetory;
        IAddBeneficiaryService<AddBeneficiaryViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new AddBeneficiaryService<AddBeneficiaryViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<AddBeneficiaryViewModel>(U, P, C, A));
            _Reposetory = new AddBeneficiaryRepository<AddBeneficiaryViewModel>(_MasterRepo, _Service);
        }

        public async Task Save()
        {
            
        }
    }
}