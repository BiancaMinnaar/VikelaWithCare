using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class AddBeneficiaryView : ProjectBaseContentPage<AddBeneficiaryViewController, AddBeneficiaryViewModel>
    {
        public AddBeneficiaryView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _ViewController.Load();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Save_Event(object sender, EventArgs e)
        {
            //Save Ben to local
            //popNav
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }
    }
}


