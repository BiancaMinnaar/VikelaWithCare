using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class SelfieView : ProjectBaseContentPage<SelfieViewController, SelfieViewModel>
    {
        public SelfieView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Capture_Event(object sender, EventArgs e)
        {
            await _ViewController.Capture();
        }

        void On_Continue_Event(object sender, System.EventArgs e)
        {
            _ViewController.UpdateSelfie();
        }
    }
}


