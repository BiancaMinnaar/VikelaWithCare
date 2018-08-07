using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class TableScrollRepository<T> : ProjectBaseRepository, ITableScrollRepository<T>
        where T : BaseViewModel
    {
        ITableScrollService<T> _Service;

        public TableScrollRepository(IMasterRepository masterRepository, ITableScrollService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Load(TableScrollViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Load(model);
            completeAction(serviceReturnModel);
        }
    }
}