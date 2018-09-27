using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.Service.ReturnModel;
using Vikela.Trunk.ViewModel.Interfaces;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Interface.Repository
{
    public interface IRegisterRepository
    {
        Task SetUserRecordWithRegisterViewModelAsync(RegisterViewModel model);
        Task SetUserRecordWithRegisterViewModelAsync(UserModel model);
        void OAuthFacebook(RegisterViewModel model);
        void OAuthInstagram(RegisterViewModel model);
        void OAuthGoogle(RegisterViewModel model);
        Task CallForImageBlobStorageSASAsync(RegisterViewModel model);
        Task<GetUserReturnModel> RegisterWithD365Async(RegisterViewModel model);
        RegisterViewModel GetUserFromARToken(IAuthenticationResult ar);
        RegisterViewModel GetDyn365RegisterViewModel();
        Task<GetUserReturnModel> GetUserWithOIDAsync(RegisterViewModel model);
        Task SetUserWithServerDataAsync(string responseContent);
        Task SetUserContactsFromServerAsync(RegisterViewModel model);
        Task SetUserPoliciesFromServerAsync(RegisterViewModel model);
        Task SetCommunityValueFromServiceAsync(RegisterViewModel model);
    }
}
