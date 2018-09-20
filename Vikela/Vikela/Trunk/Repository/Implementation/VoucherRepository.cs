using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Repository
{
    public class VoucherRepository : ProjectBaseRepository, IVoucherRepository
    {
        IVoucherService _Service;

        public VoucherRepository(IMasterRepository masterRepository, IVoucherService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task YourMethodName(VoucherViewModel model, Action completeAction)
        {
            await _Service.YourMethodName(model);
            completeAction();
        }
    }
}