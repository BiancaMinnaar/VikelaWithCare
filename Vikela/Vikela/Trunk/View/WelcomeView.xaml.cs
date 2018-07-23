using System;
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

        public void On_Start_Clicked(object sender, EventArgs e)
        {
            _ViewController.Load();
        }
    }
}


