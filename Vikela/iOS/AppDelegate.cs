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
            C1.iOS.Core.LicenseManager.Key = "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";  
            C1.Xamarin.Forms.Gauge.Platform.iOS.C1GaugeRenderer.Init();
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

