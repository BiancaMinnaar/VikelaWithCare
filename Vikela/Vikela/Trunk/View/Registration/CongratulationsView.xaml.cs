using System;
using System.Threading.Tasks;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class CongratulationsView : ProjectBaseContentPage<CongratulationsViewController, CongratulationsViewModel>
    {
        public CongratulationsView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_CompleteRegistration_Clicked(object sender, EventArgs e)
        {
            await _ViewController.CompleteRegistrationAsync();
        }
    }
}


