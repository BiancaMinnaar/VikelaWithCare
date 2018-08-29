using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IAddTrustedSourceRepository<T>
        where T : BaseViewModel
    {
        Task Load(AddTrustedSourceViewModel model, Action<T> completeAction);
    }
}
