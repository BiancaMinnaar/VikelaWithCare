using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Repository.Implementation.Controls;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Implementation.ViewController
{
    public class EditProfileViewController : ProjectBaseViewController<EditProfileViewModel>, IEditProfileViewController
    {
        IEditProfileRepository<EditProfileViewModel> _Reposetory;
        IPhotoRepository photoRepo;
        IRegisterRepository _RegisterRepo;
        ISelfieRepository _selfieRepo;

        public override void SetRepositories()
        {
            _Reposetory = new EditProfileRepository<EditProfileViewModel>(_MasterRepo);
            photoRepo = new PhotoRepository(_MasterRepo);
            _RegisterRepo = new RegisterRepository(_MasterRepo, null);
            _selfieRepo = new SelfieRepository(_MasterRepo);
        }

        public void Load()
        {
            InputObject.UserProfile = _Reposetory.Load();
        }

        public void PushSettings()
        {
            _MasterRepo.PushSettings();
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }

        public async Task UpdateUserDetailAsync()
        {
            var model = _Reposetory.GetUserModelToUpdate(InputObject.UserProfile);
            await _RegisterRepo.SetUserRecordWithRegisterViewModelAsync(model);
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.UserProfile.UserImage, InputObject.UserProfile.UserID);
            await _selfieRepo.StoreSelfieAsync(storageModel);
        }

        public void CapturePhoto()
        {
            var selfie = new SelfieViewModel
            {
                Selfie = InputObject.UserProfile.UserImage
            };
            photoRepo.SelectPictureFromGallery(selfie);
        }
    }
}