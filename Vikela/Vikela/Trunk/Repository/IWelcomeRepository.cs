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
        RegisterViewModel GetUserFromARToken(AuthenticationResult ar);
        Task SetAzureCredentialsAsync(RegisterViewModel model, string responseContent);
        Task GetUserSelfieFromStorageAsync();
        Task RegisterUserOn365Async(RegisterViewModel model);
        bool IsUserImageOnLocalStorage();
        void RegisterOrShowProfile(bool isRegistered);
    }
}
