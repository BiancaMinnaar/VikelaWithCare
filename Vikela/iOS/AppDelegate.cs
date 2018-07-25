using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Vikela.iOS.Injection.Facebook;
using Vikela.Trunk.Injection.Base;

namespace Vikela.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            PlatformSingleton.Instance.PlatformServiceList.Add<FacebookService>(
                this);
            var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
            x = typeof(Xamarin.Forms.Themes.LightThemeResources);
            x = typeof(Xamarin.Forms.Themes.iOS.UnderlineEffect);
            return base.FinishedLaunching(app, options);
        }
    }
}

