using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Trunk.View.Community.Tiles
{
    public partial class CommunityTileView : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        protected ITableScrollItemModel _Model;

        public CommunityTileView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        public CommunityTileView(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (CommunityTileViewModel)model;
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_YourMethodName_EventAsync(object sender, EventArgs e)
        {
        }
    }
}


