using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IMyCoverRepository<T>
        where T : BaseViewModel
    {
        Task Load(MyCoverViewModel model, Action<T> completeAction);
    }
}
