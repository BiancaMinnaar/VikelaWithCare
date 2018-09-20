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
    public class ChatViewController : ProjectBaseViewController<ChatViewModel>, IChatViewController
    {
        IChatRepository _Reposetory;
        IChatService _Service;

        public override void SetRepositories()
        {
            _Service = new ChatService((U, C, A) => 
                                                           ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, C, A));
            _Reposetory = new ChatRepository(_MasterRepo, _Service);
        }

        public async Task YourMethodNameAsync()
        {
            
        }
    }
}