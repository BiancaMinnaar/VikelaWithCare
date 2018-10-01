using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.ViewController
{
    public class CareVoucehersViewController : ProjectBaseViewController<CareVoucehersViewModel>, ICareVoucehersViewController
    {
        ICareVoucehersRepository _Reposetory;
        ICareVoucehersService<CareVoucehersReturnModel> _Service;

        public override void SetRepositories()
        {
            _Service = new CareVoucehersService<CareVoucehersReturnModel>((U, C, A) =>
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<CareVoucehersReturnModel>(U, C, A));
            _Reposetory = new CareVoucehersRepository(_MasterRepo, _Service);
        }

        public async Task YourMethodNameAsync()
        {
            
        }
    }
}