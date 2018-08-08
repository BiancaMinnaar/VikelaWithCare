using System;
using System.Collections.Generic;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class TableScrollView : ProjectBaseContentView<TableScrollViewController, TableScrollViewModel>
    {
        public TableScrollView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public void SetTableWithItems(List<PersonalDetailViewModel> dataSource, Action<object> clickEvent)
        {
            Table.Children.Clear();
            foreach(var item in dataSource)
            {
                var tableItem = new PersonalDetailsTile(item);
                Table.Children.Add(tableItem);
            }
        }
    }
}


