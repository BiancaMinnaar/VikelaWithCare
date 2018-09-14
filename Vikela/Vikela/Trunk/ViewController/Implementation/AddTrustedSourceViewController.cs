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

        public void LoadTrustedSources()
        {
            InputObject.SourceDetail = _Reposetory.GetTrustedContactDetailFromMaster();
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture, InputObject.SourceDetail.UserID);
            Task.Run(async () => 
            {
                await _selfieRepo.GetSelfieAsync(storageModel);
                InputObject.SourceDetail.ContactPicture.Selfie = storageModel.UserPicture;
            });
        }

        public async Task SaveTrustedSourceAsync()
        {
            await _Reposetory.SaveTrustedContactAsync(InputObject.SourceDetail);
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture, InputObject.SourceDetail.UserID);
            await _selfieRepo.StoreSelfieAsync(storageModel);
            await _Reposetory.UpdateMasterWithTrustedSourceAsync(InputObject.SourceDetail);
        }

		public async Task SaveBenificiaryAsync()
		{
            await _Reposetory.SaveDefaultBeneficiaryAsync(InputObject.SourceDetail);
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture, InputObject.SourceDetail.UserID);
            await _selfieRepo.StoreSelfieAsync(storageModel);
            await _Reposetory.UpdateMasterWithBeneficiaryAsync(InputObject.SourceDetail);
		}

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }

        public void LoadBeneficiary()
        {
            InputObject.SourceDetail = _Reposetory.GetDefaultBeneniciaryFromMaster();
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture, InputObject.SourceDetail.UserID);
            Task.Run(async () =>
            {
                await _selfieRepo.GetSelfieAsync(storageModel);
                InputObject.SourceDetail.ContactPicture.Selfie = storageModel.UserPicture;
            });
        }
    }
}