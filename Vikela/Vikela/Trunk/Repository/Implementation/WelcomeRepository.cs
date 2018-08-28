using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class WelcomeRepository<T> : ProjectBaseRepository, IWelcomeRepository<T>
        where T : BaseViewModel
    {
        IWelcomeService<T> _Service;
        IRegisterRepository<RegisterViewModel> _RegisterRepo;
        ISelfieRepository<RegisterViewModel> _SelfieRepo;

        public WelcomeRepository(IMasterRepository masterRepository, IWelcomeService<T> service, 
                                 IRegisterRepository<RegisterViewModel> registerRepo,
                                ISelfieRepository<RegisterViewModel> selfieRepo)
            : base(masterRepository)
        {
            _Service = service;
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

        public bool IsRegisteredUser(bool toOverride=false)
        {
            //Has Auth?
            var isAuthenticated = _MasterRepo.DataSource.User.OID != Guid.Empty.ToString();
            //Has 356 account?
            var hasRegistrationRecord = _RegisterRepo.GetDyn365RegisterViewModel().ErrorList.Length == 0;
            var isIn365 = false;
            return toOverride || isAuthenticated && hasRegistrationRecord && isIn365;
        }

        public void RegisterOrShowProfile(bool isRegistered)
        {
            if (isRegistered)
                _MasterRepo.PushMyCoverView();
            else
                _MasterRepo.PushSelfieView();
        }

        public async Task SetAzureCredentialsAsync(RegisterViewModel model, string responseContent)
        {
            await _RegisterRepo.CallForImageBlobStorageSASAsync(model);
        }
    }
}