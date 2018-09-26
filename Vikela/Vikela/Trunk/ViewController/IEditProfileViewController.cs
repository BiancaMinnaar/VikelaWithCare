using System.Threading.Tasks;

namespace Vikela.Interface.ViewController
{
    public interface IEditProfileViewController
    {
        void Load();
        Task UpdateUserDetailAsync();
        void PopToCover();
        void CapturePhoto();
    }
}
