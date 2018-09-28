using System;
using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.Repository
{
    public class WelcomeRepository : ProjectBaseRepository, IWelcomeRepository
    {
        IRegisterRepository _RegisterRepo;
        ISelfieRepository _SelfieRepo;

        public WelcomeRepository(IMasterRepository masterRepository, 
                                 IRegisterRepository registerRepo,
                                ISelfieRepository selfieRepo)
            : base(masterRepository)
        {
            _RegisterRepo = registerRepo;
            _SelfieRepo = selfieRepo;
        }

        public async Task GetUserSelfieFromStorageAsync()
        {
            var model = new Trunk.ViewModel.StoragePictureModel()
            {
                UserID = _MasterRepo.DataSource.User.OID,
                PictureStorageSASToken = _MasterRepo.DataSource.User.PictureStorageSASToken,
                UserPicture = _MasterRepo.DataSource.User.UserPicture
            };
            await _SelfieRepo.GetSelfieAsync(model);
            _MasterRepo.DataSource.User.UserPicture = model.UserPicture;
            await _RegisterRepo.SetUserRecordWithRegisterViewModelAsync(_MasterRepo.DataSource.User);
        }

        public bool IsUserImageOnLocalStorage()
        {
            return _MasterRepo.DataSource.User.UserPicture != null && _MasterRepo.DataSource.User.UserPicture.Length > 0;
        }

        public bool IsRegisteredUser(string D365Data, bool toOverride=false)
        {
            var isAuthenticated = _MasterRepo.GetRegisteredUserOID() != Guid.Empty.ToString();
            var hasRegistrationRecord = _RegisterRepo.GetDyn365RegisterViewModel().ErrorList.Length == 0;
            var isIn365 = D365Data != string.Empty;
            return toOverride || isAuthenticated && hasRegistrationRecord && isIn365;
        }

        public void RegisterOrShowProfile(GetUserReturnModel user)
        {
            if (user != null && user.data.verified)
                _MasterRepo.PushMyCoverView();
            else if (user != null && !user.data.verified)
                _MasterRepo.PushCongratulationsView();
            else
                _MasterRepo.PushSelfieView();
        }

        public async Task SetAzureCredentialsAsync(RegisterViewModel model, string responseContent)
        {
            await _RegisterRepo.CallForImageBlobStorageSASAsync(model);
        }
    }
}