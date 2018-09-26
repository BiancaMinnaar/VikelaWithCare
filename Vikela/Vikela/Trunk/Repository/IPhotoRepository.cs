using Vikela.Implementation.ViewModel;

namespace Vikela.Trunk.Repository
{
    public interface IPhotoRepository
    {
        void SelectPictureFromGallery(SelfieViewModel model);
    }
}
