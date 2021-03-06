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
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.Repository;

namespace Vikela.Implementation.Repository
{
    public class RegisterRepository : ProjectBaseRepository, IRegisterRepository
    {
        IRegisterService _Service;
        IDynamixService _DynamixService;
        IDynamixReturnService<GetUserReturnModel> _DynamixUserReturnService;
        IDynamixReturnService<List<DynamixContact>> _DynamixReturnService;
        IDynamixReturnService<DynamixPolicy> _DynamixPolicyReturnService;
        IDynamixReturnService<DynamixCommunity> _DynamixCommunityReturnService;
        IPlatformBonsai<IPlatformModelBonsai> _PlatformBonsai;
        ISelfieRepository _SelfieRepo;
        IAzureBlobStorageRepository BlobStorageRepository;

        public RegisterRepository(IMasterRepository masterRepository, IRegisterService service, IDynamixService dynamix=null,
              IDynamixReturnService<List<DynamixContact>> dynamixReturn=null,
              IDynamixReturnService<DynamixPolicy> dynasmicPolicyReturn=null,
              IDynamixReturnService<DynamixCommunity> dynamixCommunityReturnService=null,
              IDynamixReturnService<GetUserReturnModel> dynamixUserReturnService = null)
            : base(masterRepository)
        {
            _Service = service;
            _DynamixService = dynamix;
            _DynamixReturnService = dynamixReturn;
            _DynamixPolicyReturnService = dynasmicPolicyReturn;
            _DynamixCommunityReturnService = dynamixCommunityReturnService;
            _DynamixUserReturnService = dynamixUserReturnService;
            _PlatformBonsai = new PlatformBonsai();
            BlobStorageRepository = new AzureBlobStorageRepository(_MasterRepo);
            var platform = new PlatformRepository<RegisterViewModel>(masterRepository, _PlatformBonsai)
            {
                OnError = (errs) =>
                {
                    OnError?.Invoke(errs);
                }
            };
            _SelfieRepo = new SelfieRepository(_MasterRepo);
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

        public async Task<GetUserReturnModel> RegisterWithD365Async(RegisterViewModel model)
        {
            return await _DynamixUserReturnService.RegisterUserAsync(model);
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
                UserID = _MasterRepo.DataSource.User.UserID,
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

        public async Task<GetUserReturnModel> GetUserWithOIDAsync(RegisterViewModel model)
        {
            return await _DynamixUserReturnService.GetUserWithOIDAsync(model);

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
            localUser.BarCode = Convert.FromBase64String(FixBase64ForImage(userObject["barcode"].ToString()));

            return localUser;
        }

        string FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("data:image/png;base64,", String.Empty); sbText.Replace(" ", String.Empty);
            return sbText.ToString();
        }

        public async Task SetUserWithServerDataAsync(UserReturnModel user)
        {
            var localUser = GetUserModeFromUserReturnModel(user);
            await _MasterRepo.SetUserRecordAsync(localUser);
        }

        private UserModel GetUserModeFromUserReturnModel(UserReturnModel user)
        {
            var userModel = _MasterRepo.DataSource.User;
            userModel.UserID = user.userId;
            userModel.FirstName = user.firstName;
            userModel.LastName = user.lastName;
            userModel.MobileNumber = user.mobileNumber;
            userModel.IDNumber = user.idNumber;
            userModel.BarCode = Convert.FromBase64String(FixBase64ForImage(user.barcode));

            return userModel;
        }

        private async Task<List<ContactModel>> SelectContactsWithRole(RegisterViewModel model, List<DynamixContact> contacts, string role)
        {
            if (contacts != null)

            {
                var query = from source in contacts.Where(a => a.connectedRole.roleName == role)
                            select new ContactModel
                            {
                                UserID = source.userId,
                                ConnectionId = source.connectionId,
                                ContactRole = source.connectedRole.roleName,
                                FirstName = source.firstName,
                                LastName = source.lastName,
                                PictureURL = source.profileImage,
                            };

                var contactModels = query.ToList();
                foreach (var contact in contactModels)
                {
                    var storagePictureModel = new StoragePictureModel
                    {
                        TokenID = model.TokenID,
                        UserID = contact.UserID,
                        PictureStorageSASToken = model.PictureStorageSASToken
                    };
                    await BlobStorageRepository.GetBlobImageAsync(storagePictureModel);
                    contact.UserPicture = storagePictureModel.UserPicture;
                }


                return contactModels;
            }
            return null;
        }

        public async Task SetUserContactsFromServerAsync(RegisterViewModel model)
        {
            var contacts = await _DynamixReturnService.GetConnectedContactsAsync(model);
            if (contacts != null)
            {
                //var contactStore = new ContactStorageRepository(_MasterRepo, OfflineStorageRepository.Instance);
                var task = await SelectContactsWithRole(model, contacts, "Beneficiary");
                if (task.Count > 0)
                    _MasterRepo.DataSource.DefaultBeneficiary = task[0];
                _MasterRepo.DataSource.TrustedSources = await SelectContactsWithRole(model, contacts, "Trusted Friend");
                await _MasterRepo.SaveBeneficiaryAsync(_MasterRepo.DataSource.DefaultBeneficiary);
                await _MasterRepo.SaveTrustedSourceListAsync(_MasterRepo.DataSource.TrustedSources);
            }
        }

        private List<PolicyModel> getPolicyOfflineModelsFromServiceList(DynamixPolicy policies)
        {
            var query = from model in policies.Details
                        select new PolicyModel
                        {
                            beneficiaryContactId = model.Beneficiary.BeneficiaryId,
                            endDate = model.EndDate,
                            ensuredAmount = model.EnsuredAmount,
                            name = model.Name,
                            startDate = model.StartDate
                        };

            return query.ToList();
        }

        public async Task SetUserPoliciesFromServerAsync(RegisterViewModel model)
        {
            //TODO: COmplete
            var policies = await _DynamixPolicyReturnService.GetAllActivePoliciesAsync(model);
            if (policies != null)
            {
                _MasterRepo.DataSource.PolicyList = getPolicyOfflineModelsFromServiceList(policies);
                var policyListData = from policy in policies.Details
                                     select new PurchaseDetailsViewModel
                                     {
                                         PurchasedAt=policy.Store.StoreName,
                                         Product=policy.Product.ProductName,
                                         StartDate=policy.StartDate,
                                         EndDate=policy.EndDate,
                                         Cover=policy.EnsuredAmount,
                                         Premium=policy.PremiumAmount,
                                         BeneficiaryID=policy.Beneficiary.BeneficiaryId,
                                         PolicyID=policy.PolicyId};
                _MasterRepo.DataSource.PurchaseHistory = policyListData.ToList();

            }
        }

        private CommunityModel GetCommunityOfflineModelFromServiceModel(DynamixCommunity model)
        {
            if (model != null)
            return new CommunityModel
            {
                CommunityName = model.data.communityName
            };
            return null;
        }

        public async Task SetCommunityValueFromServiceAsync(RegisterViewModel model)
        {
            var community = await _DynamixCommunityReturnService.GetCommunityAsync(model);
            _MasterRepo.DataSource.Community = GetCommunityOfflineModelFromServiceModel(community);
        }
    }
}