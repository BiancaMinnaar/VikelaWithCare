using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;
using Microsoft.Identity.Client;
using Vikela.Trunk.Injection.Base;
using Vikela.Droid.Injection;
using Android.Widget;

namespace Vikela.Droid
{
    [Activity(Label = "Vikela.Droid", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static readonly int SELECT_FILE = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(this);
            LoadApplication(new App());
            PlatformSingleton.Instance.PlatformServiceList.Add<PhotoPicturePicker>(
                this);
            var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
            x = typeof(Xamarin.Forms.Themes.LightThemeResources);
            x = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
            App.UiParent = new UIParent(this);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == SELECT_FILE)
            {
                
            }
            else
            {
                AuthenticationContinuationHelper.SetAuthenticationContinuationEventArgs(requestCode, resultCode, data);
            }
        }
    }
}

