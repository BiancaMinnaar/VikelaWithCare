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
        Task Register(RegisterViewModel model, Action<UserModel> completeAction);
        void OAuthFacebook(RegisterViewModel model, Action<T> completeAction);
        void OAuthInstagram(RegisterViewModel model, Action<T> completeAction);
        void OAuthGoogle(RegisterViewModel model, Action<T> completeAction);
        Task SetImageBlobStorageSASAsync(RegisterViewModel model, Action<T> completeAction);
    }
}
