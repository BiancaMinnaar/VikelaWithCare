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
			OnPlatformServiceCallBack =
                new List<Action<string, IPlatformModelBase>>();
            Task.Run(async () =>
            {
                OfflineStorageRepo = OfflineStorageRepository.Instance;
                MasterRepo.DataSource.User = await GetUserModelFromOffline();
            });
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
                await RemoveUserRecord(DataSource.User);
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

        public async Task SetUserRecord(UserModel model)
        {
            if (!await CheckUserModelTable())
            {
                await CreateUserModelTabel();

            }
            if (await GetUserRecord() != null)
            {
                await OfflineStorageRepo.UpdateRecord(model);
            }
            else
            {
                await OfflineStorageRepo.InsertRecord(model);
            }
            DataSource.User = await GetUserModelFromOffline();
        }

        public async Task<UserModel> GetUserModelFromOffline()
        {
            var hasUserModelTable = await CheckUserModelTable();

            if (hasUserModelTable)
            {
                return await GetUserRecord();
            }
            else
            {
                await CreateUserModelTabel();
                return null;
            }
        }

        private async Task<bool> CheckUserModelTable()
        {
            return await OfflineStorageRepo.SelectScalar(
                SelectTableCount) != 0;
        }

        private async Task CreateUserModelTabel()
        {
            await OfflineStorageRepo.CreateTable<UserModel>();
        }

        private async Task<UserModel> GetUserRecord()
        {
            var list = await OfflineStorageRepo.QueryTable<UserModel>(
                SelectTopUser);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public async Task RemoveUserRecord(UserModel model)
        {
            await OfflineStorageRepo.DeleteRecord(model);
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
    }
}

