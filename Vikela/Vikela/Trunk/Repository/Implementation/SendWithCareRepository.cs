using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Repository
{
    public class SendWithCareRepository : ProjectBaseRepository, ISendWithCareRepository
    {
        ISendWithCareService _Service;

        public SendWithCareRepository(IMasterRepository masterRepository, ISendWithCareService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task YourMethodName(SendWithCareViewModel model, Action completeAction)
        {
            await _Service.YourMethodName(model);
            completeAction();
        }
    }
}