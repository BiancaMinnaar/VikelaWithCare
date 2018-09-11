using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Repository.Implementation.Controls;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.Implementation;

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
            _service = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _Reposetory = new AddTrustedSourceRepository(_MasterRepo, _service);
        }

        public void Load()
        {
            InputObject = _Reposetory.GetTrustedContactDetailFromMaster();
        }

        public async Task CapturePhotoAsync()
        {
            photoRepo.SelectPictureFromGallery(InputObject.ContactPicture);
        }
    }
}