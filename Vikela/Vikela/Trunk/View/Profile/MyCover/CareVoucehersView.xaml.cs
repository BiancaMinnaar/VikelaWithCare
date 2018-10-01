using System;
using System.Collections.Generic;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class CareVoucehersView : ProjectBaseContentPage<CareVoucehersViewController, CareVoucehersViewModel>
    {
        public CareVoucehersView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
            SetCareVoucherTile();
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_YourMethodName_EventAsync(object sender, EventArgs e)
        {
            await _ViewController.YourMethodNameAsync();
        }

        private void SetCareVoucherTile()
        {
            var TileList = new List<ITableScrollItemModel>
            {
                new CareVouceherDetailTileViewModel
                {
                    Name="Care Vouchers",
                    CareAmount="R 1500",
                },
                new CareVouceherDetailTileViewModel
                {
                    Name="Infuencer Vouchers",
                    CareAmount="R 4500",
                }
            };
            CareTiles.SetTableWithItems(TileList);
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController._MasterRepo.PopView();
        }
    }
}


