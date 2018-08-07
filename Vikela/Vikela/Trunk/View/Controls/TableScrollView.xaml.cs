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
            for (var count = 0; count < dataSource.Count; count++)
            {
                var item = new TableScrollItemViewModel()
                {
                    ListIndex = count,
                    ItemDescription = dataSource[count].ItemDescription,
                    MenuClickedCommand = new Command(clickEvent)
                };
                var menuItem = new TableScrollItemView(item);
                Menu.Children.Add(menuItem);
            }
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            _ViewController.ShowMessage("here");
        }

        public async void On_Load_Event(object sender, EventArgs e)
        {
            await _ViewController.Load();
        }
    }
}


