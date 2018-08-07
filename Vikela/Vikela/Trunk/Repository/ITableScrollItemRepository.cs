using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface ITableScrollItemRepository<T>
        where T : BaseViewModel
    {
        Task Load(TableScrollItemViewModel model, Action<T> completeAction);
    }
}
