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
    public class AddTrustedSourceViewController : ProjectBaseViewController<AddTrustedSourceViewModel>, IAddTrustedSourceViewController
    {
        IAddTrustedSourceRepository<AddTrustedSourceViewModel> _Reposetory;
        IAddTrustedSourceService<AddTrustedSourceViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new AddTrustedSourceService<AddTrustedSourceViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<AddTrustedSourceViewModel>(U, P, C, A));
            _Reposetory = new AddTrustedSourceRepository<AddTrustedSourceViewModel>(_MasterRepo, _Service);
        }

        public void Load()
        {
            
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }
    }
}