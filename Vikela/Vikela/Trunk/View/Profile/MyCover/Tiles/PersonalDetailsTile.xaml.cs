using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class PersonalDetailsTile : ProjectBaseContentView<TableScrollItemViewController, PersonalDetailViewModel>
    {
        public PersonalDetailsTile()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public PersonalDetailsTile(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (PersonalDetailViewModel)model;
            BindingContext = _ViewController.InputObject;
        }
    }
}


