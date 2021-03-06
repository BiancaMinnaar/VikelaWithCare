﻿using Vikela.Implementation.ViewController;
using Vikela.Root.View;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Trunk.View.Profile.MyCover.Tiles
{
    public partial class TrustedSourcesTile : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        public TrustedSourcesTile()
        {
            InitializeComponent();
        }

        public TrustedSourcesTile(ITableScrollItemModel model) : this()
        {
			_ViewController.InputObject = (TrustedSourcesViewModel)model;
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        void AddOne_Clicked(object sender, System.EventArgs e)
        {
            //TODO:Refactor
            _ViewController._MasterRepo.DataSource.TrustedSourceEditIndex = 0;
            _ViewController._MasterRepo.PushAddTrustedSource();
        }

        void AddTwo_Clicked(object sender, System.EventArgs e)
        {
            //TODO:Refactor
            _ViewController._MasterRepo.DataSource.TrustedSourceEditIndex = 1;
            _ViewController._MasterRepo.PushAddTrustedSource();
        }

        void AddThree_Clicked(object sender, System.EventArgs e)
        {
            //TODO:Refactor
            _ViewController._MasterRepo.DataSource.TrustedSourceEditIndex = 2;
            _ViewController._MasterRepo.PushAddTrustedSource();
        }
    }
}
