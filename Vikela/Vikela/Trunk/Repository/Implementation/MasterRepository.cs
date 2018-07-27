using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CorePCL;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Root.ViewModel;
using Newtonsoft.Json;
using Xamarin.Forms;
using Vikela.Implementation.View;
using Vikela.Trunk.Injection.Base;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;

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

        MasterRepository()
            : base(null)
        {
            DataSource = new MasterModel();
			OnPlatformServiceCallBack =
                new List<Action<string, IPlatformModelBase>>();
            var repo = new RegisterRepository<RegisterViewModel>(this, null);
            Task.Run(async () =>
            {
                MasterRepo.DataSource.User = await repo.GetUserModelFromOffline();
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
            DataSource.User = null;
            var repo = new RegisterRepository<RegisterViewModel>(this, null);
            Task.Run(async()=>await repo.RemoveUserRecord(DataSource.User));
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

        public void PushHomeView()
        {
            // _Navigation.PushAsync(new HomeView());
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
    }
}

