using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.Repository
{
    public class CareVoucehersRepository : ProjectBaseRepository, ICareVoucehersRepository
    {
        ICareVoucehersService<CareVoucehersReturnModel> _Service;

        public CareVoucehersRepository(IMasterRepository masterRepository, ICareVoucehersService<CareVoucehersReturnModel> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task YourMethodName(CareVoucehersViewModel model, Action completeAction)
        {
            await _Service.YourMethodNameAsync(model);
            completeAction();
        }
    }
}