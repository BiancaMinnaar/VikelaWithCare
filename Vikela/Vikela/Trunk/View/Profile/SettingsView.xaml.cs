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

        public async void On_Show_Event(object sender, EventArgs e)
        {
            await _ViewController.Show();
        }

        void On_Logout_Clicked(object sender, System.EventArgs e)
        {
            _ViewController._MasterRepo.PushLogOut();
            foreach (var user in App.PCA.Users) { App.PCA.Remove(user); }
        }
    }
}


