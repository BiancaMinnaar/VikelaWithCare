using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Repository
{
    public class NotifyClaimRepository : ProjectBaseRepository, INotifyClaimRepository
    {
        INotifyClaimService _Service;

        public NotifyClaimRepository(IMasterRepository masterRepository, INotifyClaimService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task YourMethodName(NotifyClaimViewModel model, Action completeAction)
        {
            await _Service.YourMethodName(model);
            completeAction();
        }
    }
}