using System;
using System.Threading.Tasks;
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
            Details.Data = _ViewController.InputObject.SourceDetail;
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Save_Event(object sender, EventArgs e)
        {
            await _ViewController.SaveBenificiaryAsync();
            _ViewController.PopToCover();
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }
    }
}


