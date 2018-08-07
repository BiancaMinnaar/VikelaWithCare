using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class TableScrollItemRepository<T> : ProjectBaseRepository, ITableScrollItemRepository<T>
        where T : BaseViewModel
    {
        ITableScrollItemService<T> _Service;

        public TableScrollItemRepository(IMasterRepository masterRepository, ITableScrollItemService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Load(TableScrollItemViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Load(model);
            completeAction(serviceReturnModel);
        }
    }
}