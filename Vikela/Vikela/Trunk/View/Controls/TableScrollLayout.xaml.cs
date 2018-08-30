using System.Collections.Generic;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Trunk.View.Controls.Factory;
using Vikela.Trunk.ViewModel.Controlls;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class TableScrollLayout : ProjectBaseContentView<TableScrollViewController, TableScrollViewModel>
    {
        public TableScrollLayout()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public void SetTableWithItems<M>(List<M> dataSource)
            where M : ITableScrollItemModel
        {
            Table.Children.Clear();
            foreach(var item in dataSource)
            {
                var factory = new TileViewFactory();
                var tableItem = factory.GetView(item);
                   
                Table.Children.Add(tableItem);
            }
        }
    }
}


