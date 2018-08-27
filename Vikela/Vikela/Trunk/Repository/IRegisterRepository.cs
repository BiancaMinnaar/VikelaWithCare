using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Interface.Repository
{
    public interface IRegisterRepository<T>
        where T : BaseViewModel
    {
        Task SetUserRecordWithRegisterViewModelAsync(RegisterViewModel model);
        Task SetUserRecordWithRegisterViewModelAsync(UserModel model);
        void OAuthFacebook(RegisterViewModel model, Action<T> completeAction);
        void OAuthInstagram(RegisterViewModel model, Action<T> completeAction);
        void OAuthGoogle(RegisterViewModel model, Action<T> completeAction);
        Task CallForImageBlobStorageSASAsync(RegisterViewModel model);
        Task RegisterWithD365Async(RegisterViewModel model);
    }
}
