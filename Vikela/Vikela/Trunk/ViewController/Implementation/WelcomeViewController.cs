using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class WelcomeViewController : ProjectBaseViewController<WelcomeViewModel>, IWelcomeViewController
    {
        IWelcomeRepository<WelcomeViewModel> _Reposetory;
        IWelcomeService<WelcomeViewModel> _Service;
        IRegisterService _RegisterService;
        IRegisterRepository<RegisterViewModel> _RegistratioRepo;
        ISelfieRepository<RegisterViewModel> _SelfieRepo;

        public override void SetRepositories()
        {
            _Service = new WelcomeService<WelcomeViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<WelcomeViewModel>(U, P, C, A));
            _RegisterService = new RegisterService ((U, P, A) =>
                                                    ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _Reposetory = new WelcomeRepository<WelcomeViewModel>(_MasterRepo, _Service);
            _RegistratioRepo = new RegisterRepository<RegisterViewModel>(_MasterRepo, _RegisterService);
            _SelfieRepo = new SelfieRepository<RegisterViewModel>(_MasterRepo, null);
        }

        public async Task SetUserAsync(AuthenticationResult ar)
        {
            JObject user = ParseIdToken(ar.IdToken);
            var name = user["name"]?.ToString();
            var oID = user["oid"]?.ToString();
            var registration = new RegisterViewModel()
            {
                FirstName = name,
                OID = oID,
                TokenID = ar.IdToken
            };

            if (_MasterRepo.DataSource.IsRegistered)
            {
                _MasterRepo.DataSource.User.UserPicture = null;
                await _SelfieRepo.GetSelfieAsync(new Trunk.ViewModel.StoragePictureModel()
                {
                    UserID = _MasterRepo.DataSource.User.OID,
                    PictureStorageSASToken = _MasterRepo.DataSource.User.PictureStorageSASToken,
                    UserPicture = _MasterRepo.DataSource.User.UserPicture
                });
                _MasterRepo.PushMyCoverView();
            }
            else
            {
                await _RegistratioRepo.CallForImageBlobStorageSASAsync(registration, 
                                                                   () => _RegistratioRepo.SetPictureStorageSasTokenAsync(registration, _ResponseContent));
                _MasterRepo.PushSelfieView();
            }
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