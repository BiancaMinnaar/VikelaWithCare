using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.Implementation;

namespace Vikela.Implementation.ViewController
{
    public class AddTrustedSourceViewController : ProjectBaseViewController<AddContactViewModel>, IAddTrustedSourceViewController
    {
        IAddTrustedSourceRepository _Reposetory;
        ISelfieRepository _selfieRepo;
        IDynamixService _service;

        public override void SetRepositories()
        {
            _service = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _Reposetory = new AddTrustedSourceRepository(_MasterRepo, _service);
            _selfieRepo = new SelfieRepository(_MasterRepo);
        }

        public void LoadTrustedSourcesAsync()
        {
            _MasterRepo.ShowLoading();
            InputObject.SourceDetail = _Reposetory.GetTrustedContactDetailFromMaster();
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture, InputObject.SourceDetail.UserID);
            InputObject.SourceDetail.ContactPicture.Selfie = storageModel.UserPicture;
            _MasterRepo.HideLoading();
        }

        public void LoadBeneficiaryAsync()
        {
            _MasterRepo.ShowLoading();
            InputObject.SourceDetail = _Reposetory.GetDefaultBeneniciaryFromMaster();
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture, InputObject.SourceDetail.UserID);
            InputObject.SourceDetail.ContactPicture.Selfie = storageModel.UserPicture;
            _MasterRepo.HideLoading();
        }

        public async Task SaveTrustedSourceAsync()
        {
            _MasterRepo.ShowLoading();
            await _Reposetory.SaveTrustedContactAsync(InputObject.SourceDetail);
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture, InputObject.SourceDetail.UserID);
            await _selfieRepo.StoreSelfieAsync(storageModel);
            await _Reposetory.UpdateMasterWithTrustedSourceAsync(InputObject.SourceDetail);
            _MasterRepo.HideLoading();
        }

        public async Task SaveBenificiaryAsync()
        {
            _MasterRepo.ShowLoading();
            await _Reposetory.SaveDefaultBeneficiaryAsync(InputObject.SourceDetail);
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture, InputObject.SourceDetail.UserID);
            await _selfieRepo.StoreSelfieAsync(storageModel);
            await _Reposetory.UpdateMasterWithBeneficiaryAsync(InputObject.SourceDetail);
            _MasterRepo.HideLoading();
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }

    }
}