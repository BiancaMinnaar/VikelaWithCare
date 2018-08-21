using System;
using System.Threading.Tasks;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class RegisterView : ProjectBaseContentPage<RegisterViewController, RegisterViewModel>
    {
        public RegisterView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public void On_Facebook_Register_Event(object sender, EventArgs e)
        {
            _ViewController.OAuthFacebook();
        }

        public void On_Instagram_Register_Event(object sender, EventArgs e)
        {
            _ViewController.OAuthInstagram();
        }

        public void On_Google_Register_Event(object sender, EventArgs e)
        {
            _ViewController.OAuthGoogle();
        }

        public async void On_CreateAccount_Event(object sender, EventArgs e)
        {
            await _ViewController.RegisterAsync();
        }
    }
}


