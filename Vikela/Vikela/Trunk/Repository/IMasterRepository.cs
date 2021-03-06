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
        void InitializeDataSource();
        string GetRegisteredUserOID();
		void SetRootView(Page rootView);
        Page GetRootView();
        Task PushLogOut();
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
		Task SaveBeneficiaryAsync(ContactModel model);
        Task SaveTrustedSourceAsync(ContactModel model, int index);
        Task SaveTrustedSourceListAsync(List<ContactModel> modelList);
        Task SaveCommunityAsync(CommunityModel model);
        //Navigation
        void PushLoginView();
        void PushRegistrationView();
        void PushCongratulationsView();
        void PushMyCoverView();
        void PushSelfieView();
        void PushRegistrationName();
        void PushRegistrationEmailAddress();
        void PushRegistrationCellphone();
        void PushRegistrationOTP();
        void PushRegistrationIDNumber();
        void PushEditProfile();
        void PushSettings();
        void PushAddBeneficiary();
		void PushAddTrustedSource();
        void PushMyCommunity();
        void PushSendWithCare(Guid beneficiaryID);
        void PushPolicyDetail(Guid policyID);
        void PushMyCash();
        void PushVoucherView();
        void PushFriendDetail();
        void PushCareVoucehersView();
        void PushInfluencerVoucersView();
        void PushSiyabongaVoucherView();
    }
}

