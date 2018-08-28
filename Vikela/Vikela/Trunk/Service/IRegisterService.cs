using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IRegisterService<T>
        where T : BaseViewModel
    {
        Task RegisterEnvironmentUserAsync(RegisterViewModel model);
        Task RegisterForSASAsync(RegisterViewModel model);
    }
}

