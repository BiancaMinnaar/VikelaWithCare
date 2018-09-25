using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class SendWithCareView : ProjectBaseContentPage<SendWithCareViewController, SendWithCareViewModel>
    {
        public SendWithCareView(Guid beneficiaryID)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
            PurchaseHistory.SetTableWithItems(_ViewController.GetPurchaseDetailTileModels(beneficiaryID, HistoryClicked));
        }

        protected override void SetSVGCollection()
        {
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }

        void HistoryClicked()
        {
            _ViewController.PopToCover();
        }
    }
}


