using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.PlatformBonsai.Photo;
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
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public SelfieRepository(IMasterRepository masterRepository, ISelfieService<T> service)
            : base(masterRepository)
        {
            _Service = service;
            _ImageRepo = new ImageRepository(_MasterRepo);
            _PlatformBonsai = new PlatformBonsai();
        }

        public async Task Capture(SelfieViewModel model, Action<UserModel> completeAction)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
            {
                model.Selfie = await _ImageRepo.GetPhotoBinary(photo.GetStream());
                _MasterRepo.DataSource.User.UserPicture = model.Selfie;
                await OfflineStorageRepository.Instance.UpdateRecord(_MasterRepo.DataSource.User);
                completeAction(_MasterRepo.DataSource.User);
            }
        }

        public void Select(SelfieViewModel model)
        {
            foreach (var service in _PlatformBonsai.GetBonsaiServices)
            {
                if (service.PlatformHarness.ServiceKey == "PhotoPicturePicker")
                {
                    Action<string, IPlatformModelBase> PlatformAction = async (serviceKey, photo) =>
                        {
                            if (serviceKey.Equals("PhotoPicturePicker"))
                            {
                                var stream = ((IPhotoPicturePickerModel)photo).ImageStream;
                                model.Selfie = await _ImageRepo.GetPhotoBinary(stream);
                                _MasterRepo.DataSource.User.UserPicture = model.Selfie;
                                await OfflineStorageRepository.Instance.UpdateRecord(_MasterRepo.DataSource.User);
                            }
                        };
                    _MasterRepo.OnPlatformServiceCallBack.Add(PlatformAction);
                    service.PlatformHarness.Activate();
                }
            }
        }
    }
}