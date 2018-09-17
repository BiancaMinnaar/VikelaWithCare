using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Repository.Implementation.Controls;
using Vikela.Trunk.Service;

namespace Vikela.Implementation.ViewController
{
    public class ContactDetailViewController : ProjectBaseViewController<ContactDetailViewModel>, IContactDetailViewController
    {
        IAddTrustedSourceRepository _Reposetory;
        IDynamixService _service;
        IPhotoRepository photoRepo;

        public override void SetRepositories()
        {
            photoRepo = new PhotoRepository(_MasterRepo);
        }

        public void CapturePhoto()
        {
            photoRepo.SelectPictureFromGallery(InputObject.ContactPicture);
        }
    }
}