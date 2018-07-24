using System.Threading.Tasks;
using CorePCL;

namespace Vikela.Trunk.Repository
{
    public interface IFacebookGraphRepository<T>
        where T : BaseViewModel
    {
        Task<string> GetEmailAsync(string accessToken);
    }
}
