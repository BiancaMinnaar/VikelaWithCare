using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationNameRepository<T>
        where T : BaseViewModel
    {
        Task UpdateNameAsync(RegistrationNameViewModel model);
    }
}
