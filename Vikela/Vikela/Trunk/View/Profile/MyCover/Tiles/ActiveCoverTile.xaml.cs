using Vikela.Implementation.ViewController;
using Vikela.Root.View;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Trunk.View.Profile.MyCover.Tiles
{
    public partial class ActiveCoverTile : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        public ActiveCoverTile()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public ActiveCoverTile(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (ActiveCoverViewModel)model;
            BindingContext = _ViewController.InputObject;
        }
    }
}
