using CorePCL;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Interface.Repository
{
    public interface IEditProfileRepository<T>
        where T : BaseViewModel
    {
        ProfileModel Load();
        UserModel GetUserModelToUpdate(ProfileModel model);
    }
}
