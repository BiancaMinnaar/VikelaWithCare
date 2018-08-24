using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IRegisterService
    {
        Task RegisterEnvironmentUserAsync(RegisterViewModel model);
        Task RegisterForSASAsync(RegisterViewModel model);
        Task Register365UserAsync(RegisterViewModel model);
    }
}

