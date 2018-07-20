using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IWelcomeRepository<T>
        where T : BaseViewModel
    {
        Task Load(WelcomeViewModel model, Action<T> completeAction);
    }
}
