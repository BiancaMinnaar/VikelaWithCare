using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Microsoft.Identity.Client;
using UIKit;
using Vikela.iOS.Injection.Photo;
using Vikela.Trunk.Injection.Base;

namespace Vikela.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            
            global::Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();
            LoadApplication(new App());
            PlatformSingleton.Instance.PlatformServiceList.Add<PhotoPicturePicker>(
                this);
            var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
            x = typeof(Xamarin.Forms.Themes.LightThemeResources);
            x = typeof(Xamarin.Forms.Themes.iOS.UnderlineEffect);
            App.UiParent = new UIParent();
            return base.FinishedLaunching(app, options);
        }


        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(url);
            PlatformSingleton.Instance.Model.ShowLoaderFromPlatform();
            return true;
        }
    }
}

