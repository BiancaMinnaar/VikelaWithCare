using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface ISelfieRepository<T>
        where T : BaseViewModel
    {
        Task CapturePhotoAsync(SelfieViewModel model);
        void SelectPictureFromGallery(SelfieViewModel model);
        Task StoreSelfieAsync(StoragePictureModel model);
        Task GetSelfieAsync(StoragePictureModel model);
    }
}
