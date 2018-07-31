using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IRegistrationVerifyMobileService<T>
        where T : BaseViewModel
    {
        Task<T> UpdateOTP(RegistrationVerifyMobileViewModel model);
    }
}

