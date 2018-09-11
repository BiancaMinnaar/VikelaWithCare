using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IEditProfileRepository<T>
        where T : BaseViewModel
    {
        ProfileModel Load();
    }
}
