using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;

namespace Vikela.Implementation.View
{
    public partial class MyCommunityView : ProjectBaseContentPage<MyCommunityViewController, MyCommunityViewModel>
    {
        public MyCommunityView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _ViewController.LoadCommunity();
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }
    }
}


