using Vikela.Implementation.ViewController;
using Vikela.Root.View;
using Vikela.Root.ViewModel;

namespace Vikela.Trunk.View.Profile.MyCover.Tiles
{
    public partial class TrustedSourcesTile : ProjectBaseContentView<TableScrollItemViewController, ProjectBaseViewModel>
    {
        public TrustedSourcesTile()
        {
            InitializeComponent();
        }

        protected override void SetSVGCollection()
        {
        }
    }
}
