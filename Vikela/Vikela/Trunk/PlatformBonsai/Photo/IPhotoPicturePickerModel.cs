using System;
using System.IO;
using Vikela.Trunk.Injection.Base;

namespace Vikela.Trunk.PlatformBonsai.Photo
{
    public interface IPhotoPicturePickerModel : IPlatformModelBase
    {
        Stream ImageStream { get; set; }
    }
}
