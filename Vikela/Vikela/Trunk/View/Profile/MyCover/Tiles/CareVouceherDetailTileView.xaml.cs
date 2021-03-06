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
    public partial class CareVouceherDetailTileView : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        public CareVouceherDetailTileView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        public CareVouceherDetailTileView(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (CareVouceherDetailTileViewModel)model;
            BindingContext = _ViewController.InputObject;
        }


        protected override void SetSVGCollection()
        {
        }
    }
}


