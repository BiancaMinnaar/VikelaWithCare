using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class AddTrustedSourceRepository<T> : ProjectBaseRepository, IAddTrustedSourceRepository<T>
        where T : BaseViewModel
    {
        IAddTrustedSourceService<T> _Service;

        public AddTrustedSourceRepository(IMasterRepository masterRepository, IAddTrustedSourceService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Load(AddTrustedSourceViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Load(model);
            completeAction(serviceReturnModel);
        }
    }
}