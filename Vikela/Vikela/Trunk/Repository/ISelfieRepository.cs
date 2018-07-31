using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface ISelfieRepository<T>
        where T : BaseViewModel
    {
        Task Capture(SelfieViewModel model, Action<SelfieViewModel> completeAction);
        Task UpdateMasterDataWithUserImage(byte[] image);
    }
}
