using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IRegisterService<T>
        where T : BaseViewModel
    {
        Task<T> Register(RegisterViewModel model);
    }
}

