using System.Collections.Generic;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Trunk.Service
{
    public interface IDynamixReturnService<T>
    {
        Task<T> GetConnectedContactsAsync(RegisterViewModel model);
    }
}
