using System;
using System.IO;
using Vikela.Trunk.PlatformBonsai.Photo;

namespace Vikela.iOS.Injection.Photo
{
    public class PhotoPicturePickerModel : IPhotoPicturePickerModel
    {
        public Stream ImageStream { get; set; }

        public string ErrorMessage { get; set; }
    }
}
