using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class SettingsView : ProjectBaseContentPage<SettingsViewController, SettingsViewModel>
    {
        public SettingsView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }

        void On_Logout_Clicked(object sender, System.EventArgs e)
        {
            _ViewController._MasterRepo.DataSource.User.OID = "";
            foreach (var user in App.PCA.Users) { App.PCA.Remove(user); }
            _ViewController._MasterRepo.PushLogOut();
        }
    }
}


