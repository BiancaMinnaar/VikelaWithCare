using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace Vikela.Interface.ViewController
{
    public interface IWelcomeViewController
    {
        Task SetUserAsync(AuthenticationResult ar);
    }
}
