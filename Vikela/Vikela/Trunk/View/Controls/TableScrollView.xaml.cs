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

        public void SetMenuWithItems(List<TableScrollItemViewModel> dataSource, Action<object> clickEvent)
        {
            Menu.Children.Clear();
            foreach(var item in dataSource)
            {
                var menuItem = new TableScrollItemView(item);
                Menu.Children.Add(menuItem);
            }
        }

        public async void On_Load_Event(object sender, EventArgs e)
        {
            await _ViewController.Load();
        }
    }
}


