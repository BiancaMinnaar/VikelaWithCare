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
    public class FriendsTileViewController : ProjectBaseViewController<FriendsTileViewModel>, IFriendsTileViewController
    {
        public override void SetRepositories()
        {
        }

        public async Task YourMethodNameAsync()
        {
            
        }
    }
}