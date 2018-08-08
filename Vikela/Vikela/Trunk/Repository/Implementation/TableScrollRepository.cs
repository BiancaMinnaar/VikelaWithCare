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

        public TableScrollRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }
    }
}