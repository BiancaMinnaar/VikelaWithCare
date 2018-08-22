using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Interface.Repository
{
    public interface ISelfieRepository<T>
        where T : BaseViewModel
    {
        Task CapturePhotoAsync(SelfieViewModel model, Action<UserModel> completeAction);
        void SelectPictureFromGallery(SelfieViewModel model);
        void StoreSelfie(StoragePictureModel model);
        Task GetSelfieAsync(StoragePictureModel model);
    }
}
