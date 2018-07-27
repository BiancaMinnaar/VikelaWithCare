using System;
using System.Collections.Generic;
using Vikela.Root.ViewModel;
using Vikela.Trunk.Injection.Base;
using Xamarin.Forms;

namespace Vikela.Interface.Repository
{
    public interface IMasterRepository
    {
        MasterModel DataSource { get; set; }
        void SetRootView(Page rootView);
        Page GetRootView();
        void PushLogOut();
        void PopView();
        void PopModal();
        void ShowLoading();
        void HideLoading();
        void DumpJson<T>(string heading, T objectToDump);
        void ReportToAllListeners(string serviceKey, IPlatformModelBase model);
        Action<string[]> OnError { get; set; }
        List<Action<string, IPlatformModelBase>> OnPlatformServiceCallBack { get; set; }
        void PushHomeView();
        void PushLoginView();
        void PushRegistrationView();
        void PushCongratulationsView();
        void PushMyCoverView();
    }
}

