using Microsoft.Identity.Client;
using Vikela.Implementation.View;
using Vikela.Trunk.Repository.Implementation;
using Xamarin.Forms;

namespace Vikela
{
    public partial class App : Application
    {
        public static PublicClientApplication PCA = null;

        // Azure AD B2C Coordinates
        public static string Tenant = "vikelaproductsdev.onmicrosoft.com";
        public static string ClientId = "8c1f7220-1cbd-45ad-b5e5-b1cfdfcbb33d";
        public static string PolicySignUpSignIn = "B2C_1_vikela_sign_up_in";
        public static string PolicyEditProfile = "B2C_1_vikela_edit_profile";
        public static string PolicyResetPassword = "B2C_1_vikela_reset";

        public static string[] ApiScopes = { "https://vikelaproductsdev.onmicrosoft.com/demoapi/demo.read" };
        public static string ApiEndpoint = "https://vikelaproductsdev.azurewebsites.net/hello";




        //public static string Tenant = "fabrikamb2c.onmicrosoft.com";
        //public static string ClientId = "90c0fe63-bcf2-44d5-8fb7-b8bbc0b29dc6";
        //public static string PolicySignUpSignIn = "b2c_1_susi";
        //public static string PolicyEditProfile = "b2c_1_edit_profile";
        //public static string PolicyResetPassword = "b2c_1_reset";

        //public static string[] ApiScopes = { "https://fabrikamb2c.onmicrosoft.com/demoapi/demo.read" };
        //public static string ApiEndpoint = "https://fabrikamb2chello.azurewebsites.net/hello";

        public static string BaseAuthority = "https://login.microsoftonline.com/tfp/{Tenant}/{policy}/oauth2/v2.0/authorize";
        public static string Authority = BaseAuthority.Replace("{Tenant}", Tenant).Replace("{policy}", PolicySignUpSignIn);
        public static string AuthorityEditProfile = BaseAuthority.Replace("{Tenant}", Tenant).Replace("{policy}", PolicyEditProfile);
        public static string AuthorityResetPassword = BaseAuthority.Replace("{Tenant}", Tenant).Replace("{policy}", PolicyResetPassword);
        //public static string BaseAuthority = $"https://login.microsoftonline.com/tfp/{Tenant}/";
        //public static string Authority = $"{BaseAuthority}{PolicySignUpSignIn}";
        //public static string AuthorityEditProfile = $"{BaseAuthority}{PolicyEditProfile}";
        //public static string AuthorityResetPassword = $"{BaseAuthority}{PolicyResetPassword}";

        public static UIParent UiParent = null;

        public App()
        {
            InitializeComponent();

            PCA = new PublicClientApplication(ClientId, Authority)
            {
                RedirectUri = $"ms-app://s-1-15-2-900855338-3878894867-131759193-1908462474-3693400123-604986878-4034806201/"
            };

            var _MasterRepo = MasterRepository.MasterRepo;
            _MasterRepo.SetRootView(new NavigationPage(new WelcomeView()));
            //_MasterRepo.SetRootView(new NavigationPage(new TestHarnesView()));
            MainPage = _MasterRepo.GetRootView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

