using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Trunk.Service
{
    public interface IDynamixReturnService<T>
    {
        Task<T> GetConnectedContactsAsync(RegisterViewModel model);
        Task<T> GetAllActivePoliciesAsync(RegisterViewModel model);
    }
}
