using System;
using System.Collections.Generic;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class MyCoverView : ProjectBaseContentPage<MyCoverViewController, MyCoverViewModel>
    {
        public MyCoverView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _ViewController.Load();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var menu = new TableScrollItemViewModel()
            {
                ListIndex = 0,
                Profile = new Trunk.ViewModel.ProfileModel
                {
                    UserImage = _ViewController._MasterRepo.DataSource.User.UserPicture,
                    FirstName = _ViewController._MasterRepo.DataSource.User.FirstName,
                    LastName = _ViewController._MasterRepo.DataSource.User.LastName
                },
                MenuClickedCommand = new Command(MenuClick)
            };
            var menuList = new List<TableScrollItemViewModel> { menu };
            CoverTiles.SetMenuWithItems(menuList, MenuClick);
        }

        void MenuClick(object index)
        {
            _ViewController.PushEditProfile();
        }

        public void On_LogoutClicked(object sender, EventArgs e)
        {
            _ViewController._MasterRepo.PushLogOut();
        }

        public void OnEditProfile(object sender, System.EventArgs e)
        {
            _ViewController.PushEditProfile();
        }
    }
}


