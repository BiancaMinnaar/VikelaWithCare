using System;
using System.Collections.Generic;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class MyCoverView : ProjectBaseContentPage<MyCoverViewController, MyCoverViewModel>
    {
        public MyCoverView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
            _ViewController.Load(MenuClick, SetTrustedSourceForIndex);
            SetDetailTiles();
            SetSiyabongaTiles();
            SetActiveCoverTiles();
        }

        protected override void SetSVGCollection()
        {
        }

        private void SetActiveCoverTiles()
        {
            var secondModel = _ViewController.GetActiveCoverTileViewModel(() => { });
            secondModel.CareAmount = "R250";
            secondModel.TileColor = Color.FromHex("#F09952");
            var ActiveCoverModels = new List<ITableScrollItemModel>
            {
                _ViewController.GetActiveCoverTileViewModel(() => {}),
                secondModel
            };
            ActiveCovers.SetTableWithItems(ActiveCoverModels);
        }

        private void SetSiyabongaTiles()
        {
            var SiyabongaModels = new List<ITableScrollItemModel>
            {
                _ViewController.GetSiyabongaTileViewModel(() => {})
            };
            SiyabongaTiles.SetTableWithItems(SiyabongaModels);
        }

        private void SetDetailTiles()
        {
            var TileList = new List<ITableScrollItemModel>
            {
                _ViewController.GetPersonalDetailTileViewModel(MenuClick),
                _ViewController.GetTrustedSourcesTileViewModel(SetTrustedSourceForIndex)
            };
            DetailTiles.SetTableWithItems(TileList);
        }

        void MenuClick()
        {
            _ViewController.PushEditProfile();
        }

        void SetTrustedSourceForIndex(object index)
        {

        }

        public void On_LogoutClicked(object sender, EventArgs e)
        {
            _ViewController._MasterRepo.PushLogOut();
        }

        public void OnEditProfile(object sender, System.EventArgs e)
        {
            _ViewController.PushEditProfile();
        }

        public async void OnCoverTapped(object sender, System.EventArgs e)
        {
			await _ViewController.RegisterAsync();
        }

        public void OnCircleTapped(object sender, EventArgs eventArgs)
        {
            _ViewController.PushAddBeneficiary();
        }
    }
}


