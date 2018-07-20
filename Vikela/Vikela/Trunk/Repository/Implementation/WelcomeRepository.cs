using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class WelcomeRepository<T> : ProjectBaseRepository, IWelcomeRepository<T>
        where T : BaseViewModel
    {
        IWelcomeService<T> _Service;

        public WelcomeRepository(IMasterRepository masterRepository, IWelcomeService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Load(WelcomeViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Load(model);
            completeAction(serviceReturnModel);
        }
    }
}