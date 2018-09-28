using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Interface.Repository
{
    public interface IWelcomeRepository
    {
        Task SetAzureCredentialsAsync(RegisterViewModel model, string responseContent);
        Task GetUserSelfieFromStorageAsync();
        bool IsUserImageOnLocalStorage();
        void RegisterOrShowProfile(GetUserReturnModel user);
        bool IsRegisteredUser(string D365Data, bool toOverride=false);
    }
}
