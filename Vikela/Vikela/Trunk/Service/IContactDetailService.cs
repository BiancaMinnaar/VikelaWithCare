using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IContactDetailService<T>
        where T : BaseViewModel
    {
        Task<T> Load(ContactDetailViewModel model);
    }
}

