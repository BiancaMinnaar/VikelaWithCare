using System.Threading.Tasks;

namespace Vikela.Interface.ViewController
{
    public interface ICongratulationsViewController
    {
        Task CompleteRegistrationAsync();
        void Logout();
    }
}
