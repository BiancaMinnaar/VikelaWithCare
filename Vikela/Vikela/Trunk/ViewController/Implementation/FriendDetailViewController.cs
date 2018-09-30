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
    public class FriendDetailViewController : ProjectBaseViewController<FriendDetailViewModel>, IFriendDetailViewController
    {
        IFriendDetailRepository<FriendDetailViewModel> _Reposetory;
        IFriendDetailService<FriendDetailViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new FriendDetailService<FriendDetailViewModel>((U, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<FriendDetailViewModel>(U, C, A));
            _Reposetory = new FriendDetailRepository<FriendDetailViewModel>(_MasterRepo, _Service);
        }

        public async Task YourMethodNameAsync()
        {
            
        }
    }
}