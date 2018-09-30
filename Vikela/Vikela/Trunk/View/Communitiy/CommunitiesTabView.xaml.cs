using System;
using System.Collections.Generic;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class CommunitiesTabView : ProjectBaseContentView<CommunitiesTabViewController, CommunitiesTabViewModel>
    {
        private int tabIndex = 0;
        public CommunitiesTabView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
            LoadCareTable();
        }

        private void LoadCareTable()
        {
            var models = new List<ITableScrollItemModel>
            {
                new CommunityTileViewModel
                {
                    TotalCover = "R30 000",
                    Selfie=_ViewController._MasterRepo.DataSource.User.UserPicture,
                    Name = "Hoenderplaas",
                    Subscrit = "Most Well Cared for",
                    TotalClaimsPaid = "R20 000"
                },
                new CommunityTileViewModel
                {
                    TotalCover = "R22 400",
                    Selfie=_ViewController._MasterRepo.DataSource.TrustedSources[0].UserPicture,
                    Name = "The Mustangs",
                    TotalClaimsPaid = "R18 930"
                },
                new CommunityTileViewModel
                {
                    TotalCover = "R15 903",
                    Selfie=_ViewController._MasterRepo.DataSource.TrustedSources[0].UserPicture,
                    Name = "The Hive",
                    TotalClaimsPaid = "R14 900"
                }
            };
            CareTable.SetTableWithItems(models);
        }

        protected override void SetSVGCollection()
        {
        }

        

        public async void On_YourMethodName_EventAsync(object sender, EventArgs e)
        {
            await _ViewController.YourMethodNameAsync();
        }
    }
}


