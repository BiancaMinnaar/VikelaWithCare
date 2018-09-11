using System.Collections.Generic;
using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Trunk.Service
{
    public interface IDynamixPolicyService
    {
		Task<List<DynamixPolicy>> GetAllActivePoliciesAsync(RegisterViewModel model);
    }
}
