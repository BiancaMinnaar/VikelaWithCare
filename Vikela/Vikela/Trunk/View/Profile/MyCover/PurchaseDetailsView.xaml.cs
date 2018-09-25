using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class PurchaseDetailsView : ProjectBaseContentPage<PurchaseDetailsViewController, PurchaseDetailsViewModel>
    {
        public PurchaseDetailsView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_YourMethodName_EventAsync(object sender, EventArgs e)
        {
            await _ViewController.YourMethodNameAsync();
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }
    }
}


