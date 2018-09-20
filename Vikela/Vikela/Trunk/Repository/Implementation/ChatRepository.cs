using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Repository
{
    public class ChatRepository : ProjectBaseRepository, IChatRepository
    {
        IChatService _Service;

        public ChatRepository(IMasterRepository masterRepository, IChatService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task YourMethodName(ChatViewModel model, Action completeAction)
        {
            await _Service.YourMethodName(model);
            completeAction();
        }
    }
}