using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IContactDetailViewRepository<T>
        where T : BaseViewModel
    {
        Task Load(ContactDetailViewViewModel model, Action<T> completeAction);
    }
}
