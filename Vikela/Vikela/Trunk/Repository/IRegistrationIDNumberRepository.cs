using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationIDNumberRepository<T>
        where T : BaseViewModel
    {
        Task UpdateIDNumberAsync(RegistrationIDNumberViewModel model);
    }
}
