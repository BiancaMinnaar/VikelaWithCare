using System;
using System.Windows.Input;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Trunk.View.Community.Tiles
{
    public partial class FriendsTileView : ProjectBaseStackContentView<TableScrollItemViewController, ProjectBaseViewModel>
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
            _ViewController.InputObject = (FriendsTileViewModel)model;
            BindingContext = _ViewController.InputObject;
            command = model.ItemClickedCommand;
        }

        protected override void SetSVGCollection()
        {
        }
    }
}


