using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class SelfieViewController : ProjectBaseViewController<SelfieViewModel>, ISelfieViewController
    {
        ISelfieRepository<SelfieViewModel> _Reposetory;
        ISelfieService<SelfieViewModel> _Service;

        public override void SetRepositories()
        {
            _Service = new SelfieService<SelfieViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<SelfieViewModel>(U, P, C, A));
            _Reposetory = new SelfieRepository<SelfieViewModel>(_MasterRepo, _Service);
        }

        public async Task CapturePhotoAsync()
        {
            await _Reposetory.CapturePhotoAsync(InputObject, 
                                      (model) => 
            {
            });
        }

        public void Select()
        {
            _Reposetory.SelectPictureFromGallery(InputObject);
        }

        public void UpdateSelfie()
        {
            _Reposetory.StoreSelfie(new Trunk.ViewModel.StoragePictureModel() {
                UserID = _MasterRepo.DataSource.User.OID,
                PictureStorageSASToken=_MasterRepo.DataSource.User.PictureStorageSASToken,
                UserPicture=InputObject.Selfie});
            _MasterRepo.PushRegistrationCellphone();
        }
    }
}