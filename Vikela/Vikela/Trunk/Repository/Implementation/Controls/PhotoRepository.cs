using System;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.PlatformBonsai.Photo;

namespace Vikela.Trunk.Repository.Implementation.Controls
{
    public class PhotoRepository : ProjectBaseRepository, IPhotoRepository
    {
        IImageRepository _ImageRepo;
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public PhotoRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
            _PlatformBonsai = new Vikela.Trunk.Injection.Base.PlatformBonsai();
            _ImageRepo = new ImageRepository(_MasterRepo);
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

        private Action<IPlatformModelBase> addPlatformAction(SelfieViewModel model)
        {
            async void modelAction(IPlatformModelBase photo)
            {
                var stream = ((IPhotoPicturePickerModel)photo).ImageStream;
                model.Selfie = await _ImageRepo.GetPhotoBinary(stream);
            }

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
    }
}
