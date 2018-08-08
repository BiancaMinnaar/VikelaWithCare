using System.Threading.Tasks;

namespace Vikela.Interface.ViewController
{
    public interface ISelfieViewController
    {
        Task Capture();
        void Select();
        void UpdateSelfie();
    }
}
