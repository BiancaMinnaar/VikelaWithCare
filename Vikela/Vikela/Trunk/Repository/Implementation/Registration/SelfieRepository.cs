using System;
using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.PlatformBonsai.Photo;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Repository.Implementation;
using Vikela.Trunk.ViewModel;

namespace Vikela.Implementation.Repository
{
    public class SelfieRepository : ProjectBaseRepository, ISelfieRepository
    {
        IImageRepository _ImageRepo;
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;
        IAzureBlobStorageRepository _StorageRepository;

        public SelfieRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
            _ImageRepo = new ImageRepository(_MasterRepo);
            _PlatformBonsai = new PlatformBonsai();
            _StorageRepository = new AzureBlobStorageRepository(_MasterRepo);
        }

        private Action<IPlatformModelBase> addPlatformAction(SelfieViewModel model)
        {
            Action<IPlatformModelBase> modelAction = async (photo) => 
            {
                var stream = ((IPhotoPicturePickerModel)photo).ImageStream;
                model.Selfie = await _ImageRepo.GetPhotoBinary(stream);
                _MasterRepo.DataSource.User.UserPicture = model.Selfie;
                await OfflineStorageRepository.Instance.UpdateRecordAsync(_MasterRepo.DataSource.User);
            };

            Action<string, IPlatformModelBase> pr = (serviceKey, photo) =>
            {
                if (serviceKey.Equals("PhotoPicturePicker"))
                {
                    modelAction(photo);
                }
            };
            Action<string, IPlatformModelBase> PlatformAction = pr;
            _MasterRepo.OnPlatformServiceCallBack.Add(PlatformAction);
            return modelAction;
        }

        public async Task CapturePhotoAsync(SelfieViewModel model)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
            {
                model.Selfie = await _ImageRepo.GetPhotoBinary(photo.GetStream());
                _MasterRepo.DataSource.User.UserPicture = model.Selfie;
                await OfflineStorageRepository.Instance.UpdateRecordAsync(_MasterRepo.DataSource.User);
            }
        }

        public void SelectPictureFromGallery(SelfieViewModel model)
        {
            foreach (var service in _PlatformBonsai.GetBonsaiServices)
            {
                if (service.PlatformHarness.ServiceKey == "PhotoPicturePicker")
                {
                    service.PlatformHarness.ServiceCallBack = addPlatformAction(model);
                    service.PlatformHarness.Activate();
                }
            }
        }

        public StoragePictureModel GetStoragePictureModelForSelfie(byte[] contactPicture, string userID)
        {
            var myModel = new StoragePictureModel
            {
                TokenID = _MasterRepo.DataSource.User.TokenID,
                UserID = userID,
                UserPicture = contactPicture,
                PictureStorageSASToken=_MasterRepo.DataSource.User.PictureStorageSASToken
            };

            return myModel;
        }

        public async Task StoreSelfieAsync(StoragePictureModel model)
        {
            try
            {
                await _StorageRepository.SaveBlobImageAsync(model);
            }
            catch(Exception excp)
            {
                OnError?.Invoke(new string[] { excp.Message });
            }
        }

        public async Task GetSelfieAsync(StoragePictureModel model)
        {
            await _StorageRepository.GetBlobImageAsync(model);
        }
    }
}