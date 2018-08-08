using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IAddBeneficiaryService<T>
        where T : BaseViewModel
    {
        Task<T> Save(AddBeneficiaryViewModel model);
    }
}

