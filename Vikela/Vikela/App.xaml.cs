using Microsoft.Identity.Client;
using Vikela.Implementation.View;
using Vikela.Trunk.Repository.Implementation;
using Xamarin.Forms;

namespace Vikela
{
    public partial class App : Application
    {
        public static PublicClientApplication PCA = null;

        //Azure AD B2C Coordinates
        public static string Tenant = "vikelaproductsdev.onmicrosoft.com";
        public static string ClientId = "8c1f7220-1cbd-45ad-b5e5-b1cfdfcbb33d";
        public static string PolicySignUpSignIn = "B2C_1_vikela_sign_up_in";
        public static string PolicyEditProfile = "B2C_1_vikela_edit_profile";
        public static string PolicyResetPassword = "B2C_1_vikela_reset";

        public static string[] ApiScopes = { "" };
        public static string ApiEndpoint = "";

        public static string AuthorityBase = "https://login.microsoftonline.com/tfp/{tenant}/{policy}/oauth2/v2.0/authorize";
        public static string Authority = AuthorityBase.Replace("{tenant}", Tenant).Replace("{policy}", PolicySignUpSignIn);
        public static string AuthorityEditProfile = AuthorityBase.Replace("{tenant}", Tenant).Replace("{policy}", PolicyEditProfile);
        public static string AuthorityResetPassword = AuthorityBase.Replace("{tenant}", Tenant).Replace("{policy}", PolicyResetPassword);

        public static UIParent UiParent = null;

        public App()
        {
            InitializeComponent();

            PCA = new PublicClientApplication(ClientId, Authority)
            {
                RedirectUri = $"com.onmicrosoft.vikelaproductsdev.Vikela.iOS://oauth/redirect"
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

