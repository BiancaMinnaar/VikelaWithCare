using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IRegisterService
    {
        Task Register(RegisterViewModel model);
        Task RegisterForSASAsync(RegisterViewModel model);
    }
}

