using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IRegistrationEmailService<T>
        where T : BaseViewModel
    {
        Task<T> Load(RegistrationEmailViewModel model);
    }
}

