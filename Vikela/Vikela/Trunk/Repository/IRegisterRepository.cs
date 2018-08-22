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
        void OAuthFacebook(RegisterViewModel model, Action<T> completeAction);
        void OAuthInstagram(RegisterViewModel model, Action<T> completeAction);
        void OAuthGoogle(RegisterViewModel model, Action<T> completeAction);
        Task SetPictureStorageSasTokenAsync(RegisterViewModel model, string sasToken);
        Task CallForImageBlobStorageSASAsync(RegisterViewModel model, Action completeAction);
    }
}
