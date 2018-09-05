using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CorePCL;
using Newtonsoft.Json;
using Vikela.Implementation.View;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Root.ViewModel;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.ViewModel.Offline;
using Xamarin.Forms;

namespace Vikela.Trunk.Repository.Implementation
{
    public class MasterRepository : ProjectBaseRepository, IMasterRepository
    {
        private static MasterRepository _Reposetory = new MasterRepository();
        private static readonly object syncronisationLock = new object();
        public MasterModel DataSource { get; set; }
        private INavigation _Navigation;
        private Page _RootView;
        public Func<string, Dictionary<string, object>, BaseNetworkAccessEnum, Task> NetworkInterface { get; set; }
        public Func<string, Dictionary<string, ParameterTypedValue>, BaseNetworkAccessEnum, Task> NetworkInterfaceWithTypedParameters { get; set; }
        public List<Action<string, IPlatformModelBase>> OnPlatformServiceCallBack { get; set; }
        private IOfflineStorageRepository OfflineStorageRepo;
        private const string SelectTableCount = "SELECT count(1) FROM sqlite_master WHERE type = 'table' AND name = 'UserModel'";
        private const string SelectTopUser = "SELECT * FROM UserModel";

        MasterRepository()
            : base(null)
        {
            DataSource = new MasterModel();
            PlatformSingleton.Instance.Model.HideLoaderFromPlatform = HideLoading;
            PlatformSingleton.Instance.Model.ShowLoaderFromPlatform = ShowLoading;
            OnPlatformServiceCallBack =
                new List<Action<string, IPlatformModelBase>>();
            Task.Run(async () =>
            {
                OfflineStorageRepo = OfflineStorageRepository.Instance;
                MasterRepo.DataSource.User = await GetUserModelFromOfflineAsync();
            });
            DataSource.TrustedSources = GetTrustedSources();
            DataSource.TrustedSourceEditIndex = -1;
        }

        public string GetRegisteredUserOID()
		{
			if (DataSource != null && DataSource.User != null)
				return DataSource.User.OID;
			else
				return new Guid().ToString();
		}

        private List<ContactModel> GetTrustedSources()
        {
            return new List<ContactModel>
            {
                new ContactModel(),
                new ContactModel(),
                new ContactModel()
            };
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

        public void PushLogOut()
        {
            Task.Run(async () =>
            {
                await RemoveUserRecordAsync(DataSource.User);
                DataSource.User = null;
            });
            _Navigation.PopToRootAsync();
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
            UserDialogs.Instance.ShowLoading();
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
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
            if (!await CheckUserModelTableAsync())
            {
                await CreateUserModelTabelAsync();

            }
            var localUser = await GetUserRecordAsync();
            if (localUser != null)
            {
                model.OID = localUser.OID;
                var affected = await OfflineStorageRepo.UpdateRecord(model);
                var whatIsAff = affected;
            }
            else
            {
                await OfflineStorageRepo.InsertRecord(model);
            }
            DataSource.User = await GetUserModelFromOfflineAsync();
        }

        public async Task<UserModel> GetUserModelFromOfflineAsync()
        {
            var hasUserModelTable = await CheckUserModelTableAsync();

            if (hasUserModelTable)
            {
                return await GetUserRecordAsync();
            }
            else
            {
                await CreateUserModelTabelAsync();
                return null;
            }
        }

        private async Task<bool> CheckUserModelTableAsync()
        {
            return await OfflineStorageRepo.SelectScalar(
                SelectTableCount) != 0;
        }

        private async Task CreateUserModelTabelAsync()
        {
            await OfflineStorageRepo.CreateTable<UserModel>();
        }

        private async Task<UserModel> GetUserRecordAsync()
        {
            var list = await OfflineStorageRepo.QueryTable<UserModel>(
                SelectTopUser);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public async Task RemoveUserRecordAsync(UserModel model)
        {
            var list = await OfflineStorageRepo.QueryTable<UserModel>(
                SelectTopUser);
            foreach(var allModel in list)
            {
                await OfflineStorageRepo.DeleteRecord(allModel);
            }
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

        public void SaveTrustedSource(ContactModel model, int index)
        {
            //OfflineStorageRepo.QueryTable("")
            DataSource.TrustedSources[index] = model;
        }
    }
}
