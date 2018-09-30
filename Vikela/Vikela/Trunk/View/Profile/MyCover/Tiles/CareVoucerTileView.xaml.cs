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
    public partial class CareVoucerTileView : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        protected ICommand command;
        protected ITableScrollItemModel _Model;

        public CareVoucerTileView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        public CareVoucerTileView(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (CareVoucherViewModel)model;
            BindingContext = _ViewController.InputObject;
            command = model.ItemClickedCommand;
        }

        protected override void SetSVGCollection()
        {
        }

        public void PushVoucherDetail(object sender, EventArgs e)
        {
            command.Execute(((CareVoucherViewModel)_ViewController.InputObject).Index);
        }
    }
}


