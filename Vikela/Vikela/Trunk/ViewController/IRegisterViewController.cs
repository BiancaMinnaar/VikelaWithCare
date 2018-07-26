using System.Threading.Tasks;

namespace Vikela.Interface.ViewController
{
    public interface IRegisterViewController
    {
        Task Register();
        void OAuthFacebook();
        void OAuthInstagram();
        void OAuthGoogle();
    }
}
