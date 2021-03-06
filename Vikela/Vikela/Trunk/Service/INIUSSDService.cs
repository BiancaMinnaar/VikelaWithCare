using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface INIUSSDService<T>
    {
        Task<T> SendUSSDAsync(NIUSSDViewModel model);
    }
}
