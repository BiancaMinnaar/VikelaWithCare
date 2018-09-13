using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IMyCommunityRepository<T>
        where T : BaseViewModel
    {
        Task Load(MyCommunityViewModel model, Action<T> completeAction);
    }
}
