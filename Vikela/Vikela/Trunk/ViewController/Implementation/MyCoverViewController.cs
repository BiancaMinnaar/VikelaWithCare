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
    public class MyCoverViewController : ProjectBaseViewController<MyCoverViewModel>, IMyCoverViewController
    {
        IMyCoverRepository<MyCoverViewModel> _Reposetory;
        IMyCoverService<MyCoverViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new MyCoverService<MyCoverViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<MyCoverViewModel>(U, P, C, A));
            _Reposetory = new MyCoverRepository<MyCoverViewModel>(_MasterRepo, _Service);
        }

        public async Task Load()
        {
            
        }
    }
}