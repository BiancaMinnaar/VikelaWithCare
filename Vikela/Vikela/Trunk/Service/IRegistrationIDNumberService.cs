using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IRegistrationIDNumberService<T>
        where T : BaseViewModel
    {
        Task<T> UpdateIDNumber(RegistrationIDNumberViewModel model);
    }
}

