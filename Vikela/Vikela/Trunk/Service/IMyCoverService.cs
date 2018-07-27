using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IMyCoverService<T>
        where T : BaseViewModel
    {
        Task<T> Load(MyCoverViewModel model);
    }
}

