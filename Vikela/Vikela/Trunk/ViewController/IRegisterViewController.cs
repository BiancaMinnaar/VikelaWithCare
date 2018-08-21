using System.Threading.Tasks;

namespace Vikela.Interface.ViewController
{
    public interface IRegisterViewController
    {
        Task RegisterAsync();
        void OAuthFacebook();
        void OAuthInstagram();
        void OAuthGoogle();
    }
}
