using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IRegistrationEmailRepository<T>
        where T : BaseViewModel
    {
        Task UpdateEmailAsync(RegistrationEmailViewModel model);
    }
}
