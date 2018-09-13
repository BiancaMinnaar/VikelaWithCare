using System.Collections.Generic;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class MyCommunityView : ProjectBaseContentPage<MyCommunityViewController, MyCommunityViewModel>
    {
        public MyCommunityView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _ViewController.LoadCommunity();
            BindingContext = _ViewController.InputObject;
            SetDetailTiles();
        }

        protected override void SetSVGCollection()
        {
        }

        private void SetDetailTiles()
        {
            var TileList = new List<ITableScrollItemModel>
            {
                _ViewController.GetTrustedSourcesTileViewModel(SetTrustedSourceForIndex)
            };
            DetailTiles.SetTableWithItems(TileList);
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }

        void SetTrustedSourceForIndex(object index)
        {

        }
    }
}


