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
            var menuList = new List<PersonalDetailViewModel> 
            { 
                _ViewController.GetPersonalDetailTile(() => MenuClick(0)) 
            };
            CoverTiles.SetTableWithItems(menuList, MenuClick);
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


