using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface ISettingsService<T>
        where T : BaseViewModel
    {
        Task<T> Show(SettingsViewModel model);
    }
}

