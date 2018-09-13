using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IMyCommunityService<T>
        where T : BaseViewModel
    {
        Task<T> Load(MyCommunityViewModel model);
    }
}

