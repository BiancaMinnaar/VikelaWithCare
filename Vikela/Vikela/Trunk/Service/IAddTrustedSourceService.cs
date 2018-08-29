using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IAddTrustedSourceService<T>
        where T : BaseViewModel
    {
        Task<T> Load(AddTrustedSourceViewModel model);
    }
}

