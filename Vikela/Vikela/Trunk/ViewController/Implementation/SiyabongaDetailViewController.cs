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
    public class SiyabongaDetailViewController : ProjectBaseViewController<SiyabongaDetailViewModel>, ISiyabongaDetailViewController
    {
        ISiyabongaDetailRepository _Reposetory;
        ISiyabongaDetailService _Service;

        public override void SetRepositories()
        {
            _Service = new SiyabongaDetailService((U, C, A) => 
                                                           ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, C, A));
            _Reposetory = new SiyabongaDetailRepository(_MasterRepo, _Service);
        }

        public async Task YourMethodNameAsync()
        {
            
        }
    }
}