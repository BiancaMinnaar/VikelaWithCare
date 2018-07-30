using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Repository.Implementation;
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
    }
}