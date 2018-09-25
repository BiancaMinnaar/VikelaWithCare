using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class SendWithCareView : ProjectBaseContentPage<SendWithCareViewController, SendWithCareViewModel>
    {
        private Guid BeneficiaryID;

        public SendWithCareView(Guid beneficiaryID)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
			BeneficiaryID = beneficiaryID;
            Load();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        private void Load()
        {
            PurchaseHistory.SetTableWithItems(_ViewController.GetPurchaseDetailTileModels(BeneficiaryID, HistoryClicked));

        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }

        void HistoryClicked(object policyID)
        {
            _ViewController.ShowHistoryItemDetail((Guid)policyID);
        }
    }
}


