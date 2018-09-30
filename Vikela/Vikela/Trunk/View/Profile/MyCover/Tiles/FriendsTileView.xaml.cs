using System;
using System.Windows.Input;
using Vikela.Implementation.ViewController;
using Vikela.Root.View;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Trunk.View.Profile.MyCover.Tiles
{
    public partial class FriendsTileView : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        protected ICommand command;
        protected ITableScrollItemModel _Model;

        public FriendsTileView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        public FriendsTileView(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (CareVoucherViewModel)model;
            BindingContext = _ViewController.InputObject;
            command = model.ItemClickedCommand;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_YourMethodName_EventAsync(object sender, EventArgs e)
        {
        }
    }
}


