using CorePCL;
using Vikela.Trunk.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IEditProfileRepository<T>
        where T : BaseViewModel
    {
        ProfileModel Load();
    }
}
