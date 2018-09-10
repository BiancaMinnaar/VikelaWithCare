using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class AddBeneficiaryView : ProjectBaseContentPage<AddTrustedSourceViewController, AddContactViewModel>
    {
        public AddBeneficiaryView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _ViewController.LoadBeneficiary();
            BindingContext = _ViewController.InputObject;
            Details.Data = _ViewController.InputObject.SourceDetail;
        }

        protected override void SetSVGCollection()
        {
        }

        public void On_Save_Event(object sender, EventArgs e)
        {
            //Save Ben to local
            _ViewController.SaveBenificiary();
            //popNav
            _ViewController.PopToCover();
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }
    }
}


