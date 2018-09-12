using System;
using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel.Offline;
using Vikela.Trunk.Repository.Implementation;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.Service;
using Vikela.Trunk.ViewModel.Interfaces;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Linq;
using Vikela.Trunk.Service.ReturnModel;
using System.Collections.Generic;

namespace Vikela.Implementation.Repository
{
    public class RegisterRepository : ProjectBaseRepository, IRegisterRepository
    {
        IRegisterService _Service;
        IDynamixService _DynamixService;
        IDynamixReturnService<List<DynamixContact>> _DynamixReturnService;
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;

        public RegisterRepository(IMasterRepository masterRepository, IRegisterService service, IDynamixService dynamix=null, 
                                  IDynamixReturnService<List<DynamixContact>> dynamixReturn=null)
            : base(masterRepository)
        {
            _Service = service;
            _DynamixService = dynamix;
            _DynamixReturnService = dynamixReturn;
            _PlatformBonsai = new PlatformBonsai();
            var platform = new PlatformRepository<RegisterViewModel>(masterRepository, _PlatformBonsai)
            {
                OnError = (errs) =>
                {
                    OnError?.Invoke(errs);
                }
            };
        }

        public async Task SetUserRecordWithRegisterViewModelAsync(RegisterViewModel model)
        {
            var actionModel = new UserModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress,
                MobileNumber = model.MobileNumber,
                OID = model.OID,
                UserPicture = model.UserPicture,
                TokenID = model.TokenID,
                PictureStorageSASToken = model.PictureStorageSASToken
            };
            await _MasterRepo.SetUserRecordAsync(actionModel);
        }

        public async Task SetUserRecordWithRegisterViewModelAsync(UserModel model)
        {
            await _MasterRepo.SetUserRecordAsync(model);
        }

        public void OAuthFacebook(RegisterViewModel model)
        {
            foreach (var service in _PlatformBonsai.GetBonsaiServices)
            {
                if (service.PlatformHarness.ServiceKey == "FacebookService")
                {
                    _MasterRepo.OnPlatformServiceCallBack.Add((serviceKey, locationM) =>
                    {
                        if (serviceKey.Equals("FacebookService"))
                        {
                            ///TODO:Implement model update
                        }
                    });
                    service.PlatformHarness.Activate();
                }
            }
        }

        public void OAuthInstagram(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }

        public void OAuthGoogle(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task CallForImageBlobStorageSASAsync(RegisterViewModel model)
        {
            await _Service.RegisterForSASAsync(model);
        }

        public async Task<string[]> RegisterWithD365Async(RegisterViewModel model)
        {
			if (_DynamixService != null && model.ErrorList.Length == 0)
			{
                await _DynamixService.RegisterUserAsync(model);
				return new string[]{"Success"}; 
			}
            else
			{
				return model.ErrorList;
			}
        }

        public RegisterViewModel GetUserFromARToken(IAuthenticationResult ar)
        {
            JObject user = ParseIdToken(ar.IdToken);
            var name = user["name"]?.ToString();
            var oID = user["oid"]?.ToString();
            return new RegisterViewModel()
            {
                FirstName = name,
                LastName = "Edit",
                OID = oID,
                TokenID = ar.IdToken
            };
        }

        public RegisterViewModel GetDyn365RegisterViewModel()
        {
            return new RegisterViewModel()
            {
                EmailAddress = _MasterRepo.DataSource.User.EmailAddress,
                FirstName = _MasterRepo.DataSource.User.FirstName,
                IDNumber = _MasterRepo.DataSource.User.IDNumber,
                LastName = _MasterRepo.DataSource.User.LastName,
                MobileNumber = _MasterRepo.DataSource.User.MobileNumber,
                OID = _MasterRepo.DataSource.User.OID,
                UserPictureURL = "Edit",
				TokenID = _MasterRepo.DataSource.User.TokenID
            };
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

        public async Task GetUserWithOIDAsync(RegisterViewModel model)
        {
            await _DynamixService.GetUserWithOIDAsync(model);

        }

        private UserModel getUserFromResponse(string responseContent)
        {
            var responseObject = JObject.Parse(responseContent);
            var user = responseObject["data"];
            var userObject = JObject.Parse(user.ToString());
            var localUser = _MasterRepo.DataSource.User;
            localUser.UserID = userObject["userId"].ToString();
            localUser.OID = userObject["aadObjectId"].ToString();
            localUser.EmailAddress = userObject["eMailAddress"].ToString();
            localUser.FirstName = userObject["firstName"].ToString();
            localUser.LastName = userObject["lastName"].ToString();
            localUser.IDNumber = userObject["idNumber"].ToString();
            localUser.MobileNumber = userObject["mobileNumber"].ToString();
            localUser.BarCode = Encoding.ASCII.GetBytes(userObject["barcode"].ToString());

            return localUser;
        }

        public async Task SetUserWithServerDataAsync(string responseContent)
        {
            if (!responseContent.IsNullOrEmpty())
            {
                var localUser = getUserFromResponse(responseContent);
                await _MasterRepo.SetUserRecordAsync(localUser);
            }
        }

        private List<ContactModel> SelectContactsWithRole(List<DynamixContact> contacts, string role)
        {
            var query = from source in contacts.Where(a => a.connectedRole.roleName == role)
                        select new ContactModel
                        {
                            UserID = source.userId,
                            ConnectionId = source.connectionId,
                            ContactRole = source.connectedRole.roleName,
                            FirstName = source.firstName,
                            LastName = source.lastName,
                            PictureURL = source.profileImage
                        };

            return query.ToList();
        }

        public async Task SetUserContactsFromServerAsync(RegisterViewModel model)
        {
            //TODO:Check if local storage record has been synced
            var contacts = await _DynamixReturnService.GetConnectedContactsAsync(model);
            _MasterRepo.DataSource.DefaultBeneficiary = SelectContactsWithRole(contacts, "Beneficiary")[0];
            await _MasterRepo.SaveBeneficiaryAsync(_MasterRepo.DataSource.DefaultBeneficiary);
            _MasterRepo.DataSource.TrustedSources = SelectContactsWithRole(contacts, "Trusted Source");
            await _MasterRepo.SaveTrustedSourceListAsync(_MasterRepo.DataSource.TrustedSources);
        }
    }
}