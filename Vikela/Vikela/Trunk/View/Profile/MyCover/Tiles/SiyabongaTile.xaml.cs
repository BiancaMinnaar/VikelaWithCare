using Vikela.Implementation.ViewController;
using Vikela.Root.View;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Trunk.View.Profile.MyCover.Tiles
{
    public partial class SiyabongaTile : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        public SiyabongaTile()
        {
            InitializeComponent();
        }

        public SiyabongaTile(ITableScrollItemModel model) : this()
        {
            _ViewController.InputObject = (SiyabongaViewModel)model;
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }
    }
}
