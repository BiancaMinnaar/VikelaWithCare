using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Repository
{
    public class MyCashRepository : ProjectBaseRepository, IMyCashRepository
    {
        IMyCashService _Service;

        public MyCashRepository(IMasterRepository masterRepository, IMyCashService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task YourMethodName(MyCashViewModel model, Action completeAction)
        {
            await _Service.YourMethodName(model);
            completeAction();
        }
    }
}