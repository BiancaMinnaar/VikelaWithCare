using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CoreFoundation;
using CorePCL;
using Newtonsoft.Json;
using SystemConfiguration;
using Vikela.Implementation.View;
using Vikela.Interface.Repository;
using Vikela.Root;
using Vikela.Root.Repository;
using Vikela.Root.ViewModel;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.Repository.Implementation.Offline;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Offline;
using Xamarin.Forms;

namespace Vikela.Trunk.Repository.Implementation
{
    public class MasterRepository : ProjectBaseRepository, IMasterRepository
    {
        private static MasterRepository _Reposetory = new MasterRepository();
        bool isLoading = false;
        private static readonly object syncronisationLock = new object();
        public MasterModel DataSource { get; set; }
        private INavigation _Navigation;
        private Page _RootView;
        public Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> NetworkInterface { get; set; }
        public Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> NetworkInterfaceWithTypedParameters { get; set; }
        public List<Action<string, IPlatformModelBase>> OnPlatformServiceCallBack { get; set; }

        internal IUserStorageRepository UserStorageRepo;
        internal IContactStorageRepository ContactStorageRepository;
        internal IAzureBlobStorageRepository BlobStorageRepository;

        MasterRepository()
            : base(null)
        {
            DataSource = new MasterModel();
            DataSource.IsOnline = false;
            Setup();
            PlatformSingleton.Instance.Model.HideLoaderFromPlatform = HideLoading;
            PlatformSingleton.Instance.Model.ShowLoaderFromPlatform = ShowLoading;
            OnPlatformServiceCallBack =
                new List<Action<string, IPlatformModelBase>>();
            BlobStorageRepository = new AzureBlobStorageRepository(this);
            UserStorageRepo = new UserStorageRepository(this, OfflineStorageRepository.Instance);
            ContactStorageRepository = new ContactStorageRepository(this, OfflineStorageRepository.Instance);
            Task.Run(async () =>
            {
                MasterRepo.DataSource.User = await UserStorageRepo.GetUserModelFromOfflineAsync();
                InitializeDataSource();
            });
        }

        void Setup()
        {
            var reachability = new NetworkReachability(Constants.BASE_URL);
            var reachable = reachability.TryGetFlags(out NetworkReachabilityFlags flags);
            reachability.SetNotification(OnChange);
            reachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
        }

        void OnChange(NetworkReachabilityFlags flags)
        {
            DataSource.IsOnline = flags == NetworkReachabilityFlags.Reachable;
        }

        public void InitializeDataSource()
        {
            DataSource.TrustedSources = new List<ContactModel>(){new ContactModel(),new ContactModel(), new ContactModel()};
            DataSource.TrustedSourceEditIndex = -1;
            DataSource.DefaultBeneficiary = new ContactModel();
            DataSource.PolicyList = new List<PolicyModel>();
            //transactions
        }

        public string GetRegisteredUserOID()
		{
			if (DataSource != null && DataSource.User != null)
				return DataSource.User.OID;
			else
				return new Guid().ToString();
		}

        internal async Task<List<ContactModel>> GetTrustedSourcesAsync()
        {
            var dbTrustedSources = await ContactStorageRepository.GetTrustedSourcesAsync();
            if (dbTrustedSources != null && dbTrustedSources.Count == 3)
            {
                foreach(var source in dbTrustedSources)
                {
                    if (source.UserPicture == null)
                    {
                        var model = new StoragePictureModel
                        {
                            TokenID = DataSource.User.TokenID,
                            UserID = DataSource.User.UserID,
                            PictureStorageSASToken = DataSource.User.PictureStorageSASToken
                        };
                        await BlobStorageRepository.GetBlobImageAsync(model);
                        source.UserPicture = model.UserPicture;
                    }
                }
            }
            return dbTrustedSources;
        }

        internal async Task<ContactModel> GetDefaultBeneficiaryAsync()
        {
            var source = await ContactStorageRepository.GetDefaultBeneficiaryAsync(); 
            if (source != null)
            {
                var model = new StoragePictureModel
                {
                    TokenID = DataSource.User.TokenID,
                    UserID = DataSource.User.UserID,
                    PictureStorageSASToken = DataSource.User.PictureStorageSASToken
                };
                await BlobStorageRepository.GetBlobImageAsync(model);
                source.UserPicture = model.UserPicture;
            }
            return source;
        }

        internal async Task<List<PolicyModel>> GetActiveCovers()
        {
            //TODO: get policy from DB
            return new List<PolicyModel>();
        }

        public static MasterRepository MasterRepo
        {
            get { return _Reposetory; }
        }

        public void SetRootView(Page rootView)
        {
            _RootView = rootView;
            _Navigation = rootView.Navigation;
        }

        public Page GetRootView()
        {
            return _RootView;
        }

        public async Task PushLogOut()
        {
            //TODO: check if user exist.
            //await _MasterRepo.RemoveUserRecordAsync(_MasterRepo.DataSource.User);
            foreach (var user in App.PCA.Users) { App.PCA.Remove(user); }
            DataSource.User = null;
            await _Navigation.PopToRootAsync();
        }

        public void PopView()
        {
            _Navigation.PopAsync();
        }

        public void PopModal()
        {
            _Navigation.PopModalAsync();
        }

        public void ShowLoading()
        {
            if (!isLoading)
            {
                isLoading = true;
                UserDialogs.Instance.ShowLoading();
            }
        }

        public void HideLoading()
        {
            if (isLoading)
            {
                isLoading = false;
                UserDialogs.Instance.HideLoading();
            }
        }

        public void DumpJson<T>(string heading, T objectToDump)
        {
            Debug.WriteLine(heading);
            Debug.WriteLine(JsonConvert.SerializeObject(objectToDump));
        }

		public void ReportToAllListeners(string serviceKey, IPlatformModelBase model)
        {
            foreach (var listener in OnPlatformServiceCallBack)
            {
                listener?.Invoke(serviceKey, model);
            }
        }

        public async Task SetUserRecordAsync(UserModel model)
        {
            await UserStorageRepo.SetUserRecordAsync(model);
            DataSource.User = await UserStorageRepo.GetUserModelFromOfflineAsync();
        }

        public async Task<UserModel> GetUserModelFromOfflineAsync()
        {
            return await UserStorageRepo.GetUserModelFromOfflineAsync();
        }

        public async Task RemoveUserRecordAsync(UserModel model)
        {
            await UserStorageRepo.RemoveUserRecordAsync(model);
        }

        public async Task SaveTrustedSourceAsync(ContactModel model, int index)
        {
            DataSource.TrustedSources[index] = model;
            await ContactStorageRepository.SaveContactToLocalStorageAsync(model);
        }

        public async Task SaveTrustedSourceListAsync(List<ContactModel> modelList)
        {
            for (var count=0; count < modelList.Count; count ++)
                await SaveTrustedSourceAsync(modelList[count], count);
        }

        public async Task SaveBeneficiaryAsync(ContactModel model)
        {
            DataSource.DefaultBeneficiary = model;
            await ContactStorageRepository.SaveContactToLocalStorageAsync(model);
        }

        public async Task SaveCommunityAsync(CommunityModel model)
        {
            DataSource.Community = model;
            //await 
        }

        public void PushLoginView()
        {
            _Navigation.PushAsync(new LoginView());
        }
        public void PushRegistrationView()
        {
            _Navigation.PushAsync(new RegisterView());
        }

        public void PushCongratulationsView()
        {
            _Navigation.PushAsync(new CongratulationsView());
        }

        public void PushMyCoverView()
        {
            _Navigation.PushAsync(new MyCoverView());
        }

        public void PushSelfieView()
        {
            _Navigation.PushAsync(new SelfieView());
        }

        public void PushRegistrationName()
        {
            _Navigation.PushAsync(new RegistrationNameView());
        }

        public void PushRegistrationEmailAddress()
        {
            _Navigation.PushAsync(new RegistrationEmailView());
        }

        public void PushRegistrationCellphone()
        {
            _Navigation.PushAsync(new RegistrationCellphoneView());
        }

        public void PushRegistrationOTP()
        {
            _Navigation.PushAsync(new RegistrationVerifyMobileView());
        }

        public void PushRegistrationIDNumber()
        {
            _Navigation.PushAsync(new RegistrationIDNumberView());
        }

        public void PushEditProfile()
        {
            _Navigation.PushAsync(new EditProfileView());
        }

        public void PushSettings()
        {
            _Navigation.PushAsync(new SettingsView());
        }

        public void PushAddBeneficiary()
        {
            _Navigation.PushAsync(new AddBeneficiaryView());
        }

		public void PushAddTrustedSource()
		{
            _Navigation.PushAsync(new AddTrustedSourceView());
		}

        public void PushMyCommunity()
        {
            _Navigation.PushAsync(new MyCommunityView());
        }

        public void PushSendWithCare(Guid beneficiaryID)
        {
            _Navigation.PushAsync(new SendWithCareView(beneficiaryID));
        }

        public void PushPolicyDetail(Guid policyID)
        {
            _Navigation.PushAsync(new PurchaseDetailsView(policyID));
        }
    }
}
