using System;
using System.Windows.Input;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Trunk.View.Profile.MyCover.Tiles
{
    public partial class CareVouceherItemDetailTileView : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        public CareVouceherItemDetailTileView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        public CareVouceherItemDetailTileView(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (CareVouceherDetailTileViewModel)model;
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }
    }
}


