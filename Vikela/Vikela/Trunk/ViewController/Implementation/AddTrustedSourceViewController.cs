using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Repository.Implementation;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.Implementation;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.ViewController
{
    public class AddTrustedSourceViewController : ProjectBaseViewController<AddContactViewModel>, IAddTrustedSourceViewController
    {
        IAddTrustedSourceRepository addTrustedSourceRepo;
        IAddBeneficiaryRepository addBeneficiaryRepository;
        ISelfieRepository _selfieRepo;
        IDynamixService _service;

        public override void SetRepositories()
        {
            _service = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            var AddTrustedSourceService = new DynamixReturnService<DynamicTrustedSourceAddReturn>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<DynamicTrustedSourceAddReturn>(U, P, A));
            var AddBeneficiaryService = new DynamixReturnService<DynamixBeneficiaryAddReturn>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<DynamixBeneficiaryAddReturn>(U, P, A));
            addTrustedSourceRepo = new AddTrustedSourceRepository(_MasterRepo, _service, AddTrustedSourceService);
            addBeneficiaryRepository = new AddBeneficiaryRepository(_MasterRepo, _service, AddBeneficiaryService);
            _selfieRepo = new SelfieRepository(_MasterRepo);
        }

        public void LoadTrustedSources()
        {
            InputObject.SourceDetail = addTrustedSourceRepo.GetTrustedContactDetailFromMaster();
        }

        public void LoadBeneficiary()
        {
            InputObject.SourceDetail = addBeneficiaryRepository.GetDefaultBeneniciaryFromMaster();
        }

        public async Task SaveTrustedSourceAsync()
        {
            _MasterRepo.ShowLoading();
            await addTrustedSourceRepo.SaveTrustedSourceAsync(InputObject.SourceDetail);
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture.Selfie, InputObject.SourceDetail.UserID);
            await _selfieRepo.StoreSelfieAsync(storageModel);
            await addTrustedSourceRepo.UpdateMasterWithTrustedSourceAsync(InputObject.SourceDetail);
            _MasterRepo.HideLoading();
        }

        public async Task SaveBenificiaryAsync()
        {
            _MasterRepo.ShowLoading();
            await addBeneficiaryRepository.SaveDefaultBeneficiaryAsync(InputObject.SourceDetail);
            var storageModel = _selfieRepo.GetStoragePictureModelForSelfie(
                InputObject.SourceDetail.ContactPicture.Selfie, InputObject.SourceDetail.UserID);
            await _selfieRepo.StoreSelfieAsync(storageModel);
            await addBeneficiaryRepository.UpdateMasterWithBeneficiaryAsync(InputObject.SourceDetail);
            _MasterRepo.HideLoading();
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }

    }
}