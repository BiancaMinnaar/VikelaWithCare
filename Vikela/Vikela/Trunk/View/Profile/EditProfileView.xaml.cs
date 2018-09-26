using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class EditProfileView : ProjectBaseContentPage<EditProfileViewController, EditProfileViewModel>
    {
        public EditProfileView()
        {
            InitializeComponent();
            _ViewController.Load();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Edit_Event(object sender, EventArgs e)
        {
            await _ViewController.Edit();
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }

        void On_Settings_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PushSettings();
        }
    }
}


