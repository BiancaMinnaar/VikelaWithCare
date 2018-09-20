using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Repository
{
    public class PurchaseDetailsRepository : ProjectBaseRepository, IPurchaseDetailsRepository
    {
        IPurchaseDetailsService _Service;

        public PurchaseDetailsRepository(IMasterRepository masterRepository, IPurchaseDetailsService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task YourMethodName(PurchaseDetailsViewModel model, Action completeAction)
        {
            await _Service.YourMethodName(model);
            completeAction();
        }
    }
}