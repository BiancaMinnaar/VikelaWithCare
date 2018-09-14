using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface ISelfieRepository
    {
        Task CapturePhotoAsync(SelfieViewModel model);
        void SelectPictureFromGallery(SelfieViewModel model);
        StoragePictureModel GetStoragePictureModelForSelfie(SelfieViewModel model, string userID);
        Task StoreSelfieAsync(StoragePictureModel model);
        Task GetSelfieAsync(StoragePictureModel model);

    }
}
