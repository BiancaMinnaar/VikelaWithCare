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
        IRegisterService<RegisterViewModel> _RegisterService;
        IRegisterRepository<RegisterViewModel> _RegistratioRepo;

        public override void SetRepositories()
        {
            _Service = new WelcomeService<WelcomeViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<WelcomeViewModel>(U, P, C, A));
            _RegisterService = new RegisterService<RegisterViewModel> ((U, P, C, A) =>
                                                                       ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegisterViewModel>(U, P, C, A));
            _Reposetory = new WelcomeRepository<WelcomeViewModel>(_MasterRepo, _Service);
            _RegistratioRepo = new RegisterRepository<RegisterViewModel>(_MasterRepo, null, _RegisterService);
        }

        public async Task SetUser(AuthenticationResult ar)
        {
            JObject user = ParseIdToken(ar.IdToken);
            var name = user["name"]?.ToString();
            var oID = user["oid"]?.ToString();
            var registration = new RegisterViewModel()
            {
                FisrtName = name,
                OID = oID,
                TokenID = ar.IdToken
            };
            if (_MasterRepo.DataSource.IsRegistered)
            {
                _MasterRepo.DataSource.User.OID = oID;
                await _MasterRepo.SetUserRecord(_MasterRepo.DataSource.User);
                _MasterRepo.PushMyCoverView();
            }
            else
            {
                await _RegistratioRepo.Register(registration, null);
                await _RegistratioRepo.SetImageBlobStorageSASAsync(registration, (ModelIO) => 
                {
                    
                });
                _MasterRepo.PushSelfieView();
            }
        }

        JObject ParseIdToken(string idToken)
        {
            // Get the piece with actual user info
            idToken = idToken.Split('.')[1];
            idToken = Base64UrlDecode(idToken);
            return JObject.Parse(idToken);
        }

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