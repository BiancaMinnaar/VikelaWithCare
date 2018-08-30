using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IContactDetailRepository<T>
        where T : BaseViewModel
    {
        Task Load(ContactDetailViewModel model, Action<T> completeAction);
    }
}
