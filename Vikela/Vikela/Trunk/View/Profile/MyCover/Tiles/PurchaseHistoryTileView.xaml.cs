using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class PurchaseHistoryTileView : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        public PurchaseHistoryTileView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public PurchaseHistoryTileView(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (PurchaseHistoryDetailViewModel)model;
            BindingContext = _ViewController.InputObject;
        }
    }
}


