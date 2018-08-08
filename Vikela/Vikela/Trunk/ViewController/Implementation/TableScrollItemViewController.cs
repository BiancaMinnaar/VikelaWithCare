using Vikela.Implementation.ViewModel;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class TableScrollItemViewController : ProjectBaseViewController<PersonalDetailViewModel>, ITableScrollItemViewController
    {
        public override void SetRepositories()
        {
        }
    }
}