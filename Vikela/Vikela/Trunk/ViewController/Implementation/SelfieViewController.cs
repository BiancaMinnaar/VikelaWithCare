using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class SelfieViewController : ProjectBaseViewController<SelfieViewModel>, ISelfieViewController
    {
        ISelfieRepository _Reposetory;

        public override void SetRepositories()
        {
            _Reposetory = new SelfieRepository(_MasterRepo);
            InputObject.Selfie = _MasterRepo.DataSource.User.UserPicture;
        }

        public async Task CapturePhotoAsync()
        {
            await _Reposetory.CapturePhotoAsync(InputObject);
        }

        public void Select()
        {
            _Reposetory.SelectPictureFromGallery(InputObject);
        }

        public void UpdateSelfie()
        {
            _Reposetory.StoreSelfieAsync(new Trunk.ViewModel.StoragePictureModel() {
                UserID = _MasterRepo.DataSource.User.OID,
                PictureStorageSASToken=_MasterRepo.DataSource.User.PictureStorageSASToken,
                UserPicture=InputObject.Selfie});
            _MasterRepo.PushRegistrationName();
        }
    }
}