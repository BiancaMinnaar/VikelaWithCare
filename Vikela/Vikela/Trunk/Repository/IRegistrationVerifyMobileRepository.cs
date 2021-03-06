using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationVerifyMobileRepository<T>
        where T : BaseViewModel
    {
        Task UpdateOTPAsync(RegistrationVerifyMobileViewModel model);
    }
}
