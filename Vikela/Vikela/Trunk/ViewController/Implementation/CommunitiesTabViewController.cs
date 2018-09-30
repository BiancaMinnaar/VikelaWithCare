using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class CommunitiesTabViewController : ProjectBaseViewController<CommunitiesTabViewModel>, ICommunitiesTabViewController
    {
        public override void SetRepositories()
        {
        }

        public async Task YourMethodNameAsync()
        {
            
        }
    }
}