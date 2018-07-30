using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class SelfieRepository<T> : ProjectBaseRepository, ISelfieRepository<T>
        where T : BaseViewModel
    {
        ISelfieService<T> _Service;

        public SelfieRepository(IMasterRepository masterRepository, ISelfieService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Capture(SelfieViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Capture(model);
            completeAction(serviceReturnModel);
        }
    }
}