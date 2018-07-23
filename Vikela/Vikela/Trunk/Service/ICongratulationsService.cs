using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface ICongratulationsService<T>
        where T : BaseViewModel
    {
        Task<T> Done(CongratulationsViewModel model);
    }
}

