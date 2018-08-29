using System;
using System.Threading.Tasks;
using CorePCL;
using Microsoft.Identity.Client;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IWelcomeRepository<T>
        where T : BaseViewModel
    {
        Task SetAzureCredentialsAsync(RegisterViewModel model, string responseContent);
        Task GetUserSelfieFromStorageAsync();
        bool IsUserImageOnLocalStorage();
        void RegisterOrShowProfile(bool isRegistered);
        bool IsRegisteredUser(string D365Data, bool toOverride=false);
    }
}
