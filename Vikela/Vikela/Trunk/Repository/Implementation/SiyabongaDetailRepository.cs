using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Repository
{
    public class SiyabongaDetailRepository : ProjectBaseRepository, ISiyabongaDetailRepository
    {
        ISiyabongaDetailService _Service;

        public SiyabongaDetailRepository(IMasterRepository masterRepository, ISiyabongaDetailService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task YourMethodName(SiyabongaDetailViewModel model, Action completeAction)
        {
            await _Service.YourMethodName(model);
            completeAction();
        }
    }
}