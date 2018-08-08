using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using Vikela.Trunk.Injection.Base;
using Vikela.Trunk.PlatformBonsai.Photo;

namespace Vikela.iOS.Injection.Photo
{
    public class PhotoPicturePicker : PlatformServiceBonsai<IPlatformModelBase>, IPhotoPicturePicker<IPlatformModelBase>
    {
        public override string ServiceKey => "PhotoPicturePicker";
        UIImagePickerController imagePicker;

        public override void Activate()
        {
            base.Activate();
            PresentImagePicker();
        }

        public void PresentImagePicker()
        {
            // Create and define UIImagePickerController
            imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };

            // Set event handlers
            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled += OnImagePickerCancelled;

            // Present UIImagePickerController;
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(imagePicker, true);


        }

        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            UIImage image = args.EditedImage ?? args.OriginalImage;

            if (image != null)
            {
                // Convert UIImage to .NET Stream object
                NSData data = image.AsJPEG(1);
                Stream stream = data.AsStream();

                ExecuteCallBack(new PhotoPicturePickerModel { ImageStream=stream});

               
            }
            imagePicker.DismissModalViewController(true);
        }

        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            imagePicker.DismissModalViewController(true);
        }
    }
}
