using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IWelcomeService<T>
        where T : BaseViewModel
    {
        Task<T> Load(WelcomeViewModel model);
    }
}

