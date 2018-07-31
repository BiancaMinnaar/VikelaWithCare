using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Repository.Implementation;
using Vikela.Trunk.ViewModel.Offline;
using Xamarin.Forms;

namespace Vikela.Implementation.Repository
{
    public class SelfieRepository<T> : ProjectBaseRepository, ISelfieRepository<T>
        where T : BaseViewModel
    {
        ISelfieService<T> _Service;
        IImageRepository _ImageRepo;

        public SelfieRepository(IMasterRepository masterRepository, ISelfieService<T> service)
            : base(masterRepository)
        {
            _Service = service;
            _ImageRepo = new ImageRepository(_MasterRepo);
        }

        public async Task Capture(SelfieViewModel model, Action<SelfieViewModel> completeAction)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
            {
                model.Selfie = await _ImageRepo.GetPhotoBinary(photo.GetStream());
                completeAction(model);
            }
        }

        public async Task UpdateMasterDataWithUserImage(byte[] image)
        {
            var isInsert = false;
            int id = 0;
            if (_MasterRepo.DataSource.User == null)
            {
                _MasterRepo.DataSource.User = new UserModel();
                isInsert = true;
            }
            _MasterRepo.DataSource.User.UserPicture = image;
            if (isInsert)
                await OfflineStorageRepository.Instance.InsertRecord(_MasterRepo.DataSource.User);
            else
                id = await OfflineStorageRepository.Instance.UpdateRecord(_MasterRepo.DataSource.User);
            var dd = id;
        }
    }
}