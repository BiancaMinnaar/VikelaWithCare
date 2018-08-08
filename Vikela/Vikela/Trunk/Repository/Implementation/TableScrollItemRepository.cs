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

        public TableScrollItemRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }
    }
}