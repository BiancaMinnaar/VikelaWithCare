using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class CongratulationsRepository<T> : ProjectBaseRepository, ICongratulationsRepository<T>
        where T : BaseViewModel
    {
        ICongratulationsService<T> _Service;

        public CongratulationsRepository(IMasterRepository masterRepository, ICongratulationsService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Done(CongratulationsViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Done(model);
            completeAction(serviceReturnModel);
        }
    }
}