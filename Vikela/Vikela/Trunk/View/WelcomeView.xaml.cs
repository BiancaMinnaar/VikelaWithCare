using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class WelcomeView : ProjectBaseContentPage<WelcomeViewController, WelcomeViewModel>
    {
        public WelcomeView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }
           

        protected override void SetSVGCollection()
        {
        }

        public async void On_Start_Clicked(object sender, EventArgs e)
        {
            AuthenticationResult ar = App.PCA.Users.Any()
                ? await App.PCA.AcquireTokenSilentAsync(App.ApiScopes, GetUserByPolicy(App.PCA.Users, App.PolicySignUpSignIn), App.Authority, false)
                : await App.PCA.AcquireTokenAsync(App.ApiScopes, GetUserByPolicy(App.PCA.Users, App.PolicySignUpSignIn), App.UiParent);
            await _ViewController.SetUserAsync(ar);
        }

        private IUser GetUserByPolicy(IEnumerable<IUser> users, string policy)
        {
            foreach (var user in users)
            {
                string userIdentifier = Base64UrlDecode(user.Identifier.Split('.')[0]);
                if (userIdentifier.EndsWith(policy.ToLower())) return user;
            }

            return null;
        }

        private string Base64UrlDecode(string s)
        {
            s = s.Replace('-', '+').Replace('_', '/');
            s = s.PadRight(s.Length + (4 - s.Length % 4) % 4, '=');
            var byteArray = Convert.FromBase64String(s);
            var decoded = Encoding.UTF8.GetString(byteArray, 0, byteArray.Count());
            return decoded;
        }
    }
}


