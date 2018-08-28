using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorePCL;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
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

        public RegisterViewModel GetUserFromARToken(AuthenticationResult ar)
        {
            JObject user = ParseIdToken(ar.IdToken);
            var name = user["name"]?.ToString();
            var oID = user["oid"]?.ToString();
            return new RegisterViewModel()
            {
                FirstName = name,
                OID = oID,
                TokenID = ar.IdToken
            };
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

        //TODO: refactor
        JObject ParseIdToken(string idToken)
        {
            // Get the piece with actual user info
            idToken = idToken.Split('.')[1];
            idToken = Base64UrlDecode(idToken);
            return JObject.Parse(idToken);
        }
        //TODO: refactor
        private string Base64UrlDecode(string s)
        {
            s = s.Replace('-', '+').Replace('_', '/');
            s = s.PadRight(s.Length + (4 - s.Length % 4) % 4, '=');
            var byteArray = Convert.FromBase64String(s);
            var decoded = Encoding.UTF8.GetString(byteArray, 0, byteArray.Count());
            return decoded;
        }
    }
}