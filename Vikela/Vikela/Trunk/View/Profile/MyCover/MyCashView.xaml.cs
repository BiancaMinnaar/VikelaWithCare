using System;
using System.Collections.Generic;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class MyCashView : ProjectBaseContentPage<MyCashViewController, MyCashViewModel>
    {
        public MyCashView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
            SetCareVoucherTile();
        }

        protected override void SetSVGCollection()
        {
        }

        private void SetCareVoucherTile()
        {
            var TileList = new List<ITableScrollItemModel>
            {
                new CareVoucherViewModel
                {
                    VoucherName="Care Vouchers",
                    DisplayAmount="R 1500",
                    ItemClickedCommand=new Command(PushVoucherView)
                }
            };
            VoucerTable.SetTableWithItems(TileList);
        }

        void Back_Clicked(object sender, System.EventArgs e)
        {
            _ViewController.PopToCover();
        }

        void PushVoucherView(object index)
        {
            _ViewController.PushVoucherDetail();
        }
    }
}


