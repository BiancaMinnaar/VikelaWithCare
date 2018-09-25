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
    public class PurchaseDetailsViewController : ProjectBaseViewController<PurchaseDetailsViewModel>, IPurchaseDetailsViewController
    {
        IPurchaseDetailsRepository _Reposetory;
        IPurchaseDetailsService _Service;

        public override void SetRepositories()
        {
            _Service = new PurchaseDetailsService((U, C, A) => 
                                                           ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, C, A));
            _Reposetory = new PurchaseDetailsRepository(_MasterRepo, _Service);
        }

        public async Task YourMethodNameAsync()
        {
            
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }
    }
}