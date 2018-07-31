using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Interface.Repository
{
    public interface ISelfieRepository<T>
        where T : BaseViewModel
    {
        Task Capture(SelfieViewModel model, Action<UserModel> completeAction);
    }
}
