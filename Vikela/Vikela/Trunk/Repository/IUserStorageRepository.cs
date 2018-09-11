using System.Threading.Tasks;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository
{
    public interface IUserStorageRepository
    {
        //Offline
        Task<UserModel> GetUserModelFromOfflineAsync();
        Task SetUserRecordAsync(UserModel model);
        Task RemoveUserRecordAsync(UserModel model);
    }
}
