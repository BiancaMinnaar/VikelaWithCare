using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;

namespace Vikela.Implementation.ViewController
{
    public class MonthRadialGraphViewController : ProjectBaseViewController<MonthRadialGraphViewModel>, IMonthRadialGraphViewController
    {
        IMonthRadialGraphRepository _Reposetory;

        public override void SetRepositories()
        {
            _Reposetory = new MonthRadialGraphRepository(_MasterRepo);
        }
    }
}