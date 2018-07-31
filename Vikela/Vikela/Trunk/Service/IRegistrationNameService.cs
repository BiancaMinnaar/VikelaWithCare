using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IRegistrationNameService<T>
        where T : BaseViewModel
    {
        Task<T> UpdateName(RegistrationNameViewModel model);
    }
}

