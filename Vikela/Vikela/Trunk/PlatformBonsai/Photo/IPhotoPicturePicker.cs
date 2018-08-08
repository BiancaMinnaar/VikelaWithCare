using Vikela.Trunk.Injection.Base;

namespace Vikela.Trunk.PlatformBonsai.Photo
{
    public interface IPhotoPicturePicker<T> : IPlatformService<T> where T : IPlatformModelBase
    {
        void PresentImagePicker();
    }
}
