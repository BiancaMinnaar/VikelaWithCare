using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface ISelfieService<T>
        where T : BaseViewModel
    {
        Task<T> Capture(SelfieViewModel model);
    }
}

