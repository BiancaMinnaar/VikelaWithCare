using System.Threading.Tasks;

namespace Vikela.Interface.ViewController
{
    public interface ISelfieViewController
    {
        Task CapturePhotoAsync();
        void Select();
        void UpdateSelfie();
    }
}
