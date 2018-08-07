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
    public class TableScrollViewController : ProjectBaseViewController<TableScrollViewModel>, ITableScrollViewController
    {
        ITableScrollRepository<TableScrollViewModel> _Reposetory;
        ITableScrollService<TableScrollViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new TableScrollService<TableScrollViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<TableScrollViewModel>(U, P, C, A));
            _Reposetory = new TableScrollRepository<TableScrollViewModel>(_MasterRepo, _Service);
        }

        public async Task Load()
        {
            
        }
    }
}