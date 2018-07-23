using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface ILoginService<T>
        where T : BaseViewModel
    {
        Task<T> Login(LoginViewModel model);
    }
}

