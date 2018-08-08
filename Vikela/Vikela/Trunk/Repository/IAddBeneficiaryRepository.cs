using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IAddBeneficiaryRepository<T>
        where T : BaseViewModel
    {
        Task Save(AddBeneficiaryViewModel model, Action<T> completeAction);
    }
}
