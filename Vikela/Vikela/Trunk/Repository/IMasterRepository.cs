using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vikela.Root.ViewModel;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.ViewModel.Offline;
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
        //Offline
        Task<UserModel> GetUserModelFromOfflineAsync();
        Task SetUserRecordAsync(UserModel model);
        Task RemoveUserRecordAsync(UserModel model);
        //Navigation
        void PushLoginView();
        void PushRegistrationView();
        void PushCongratulationsView();
        void PushMyCoverView();
        void PushSelfieView();
        void PushRegistrationName();
        void PushRegistrationCellphone();
        void PushRegistrationOTP();
        void PushRegistrationIDNumber();
        void PushEditProfile();
        void PushSettings();
    }
}

