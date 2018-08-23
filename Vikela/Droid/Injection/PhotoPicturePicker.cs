using Android.Content;
using Android.Provider;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.PlatformBonsai.Photo;

namespace Vikela.Droid.Injection
{
    public class PhotoPicturePicker : PlatformServiceBonsai<IPlatformModelBase>, IPhotoPicturePicker<IPlatformModelBase>
    {
        public override string ServiceKey => "PhotoPicturePicker";
        Intent galleryIntent;
        Context context = Android.App.Application.Context;

        public override void Activate()
        {
            base.Activate();
            PresentImagePicker();
        }

        public void PresentImagePicker()
        {
            var intent = new Intent(Intent.ActionPick, MediaStore.Images.Media.ExternalContentUri);
            intent.SetType("image/*");
            context.StartActivity(Intent.CreateChooser(intent, "Select Picture"));
        }
    }
}
