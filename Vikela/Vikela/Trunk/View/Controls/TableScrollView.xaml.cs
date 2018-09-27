using System.Collections.Generic;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Vikela.Trunk.View.Controls.Factory;
using Vikela.Trunk.ViewModel.Controlls;
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

        public void SetTableWithItems<M>(List<M> dataSource)
            where M : ITableScrollItemModel
        {
            if (dataSource != null)
            {
                Table.Children.Clear();
                foreach (var item in dataSource)
                {
                    var factory = new TileViewFactory();
                    var tableItem = factory.GetView(item);

                    Table.Children.Add(tableItem);
                }
            }
        }
    }
}


