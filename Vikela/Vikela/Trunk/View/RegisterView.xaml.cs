using System;
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

        public void On_Register_Event(object sender, EventArgs e)
        {
            _ViewController.Register();
        }
    }
}


