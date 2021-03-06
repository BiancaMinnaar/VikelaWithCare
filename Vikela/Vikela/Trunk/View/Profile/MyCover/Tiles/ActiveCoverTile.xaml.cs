﻿using System;
using System.Windows.Input;
using Vikela.Implementation.View;
using Vikela.Implementation.ViewController;
using Vikela.Root.View;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Trunk.View.Profile.MyCover.Tiles
{
    
    public partial class ActiveCoverTile : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        protected ICommand command;
        protected ITableScrollItemModel _Model;

        public ActiveCoverTile()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        

        public ActiveCoverTile(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (ActiveCoverViewModel)model;
            BindingContext = _ViewController.InputObject;
            command = model.ItemClickedCommand;
        }

        public void PushSendWithCare(object sender, EventArgs e)
        {
            command.Execute(((ActiveCoverViewModel)_ViewController.InputObject).Index);
        }

        public void AddBeneficiary(object sender, EventArgs e)
        {
            _ViewController._MasterRepo.PushAddBeneficiary();
        }
    }
}
