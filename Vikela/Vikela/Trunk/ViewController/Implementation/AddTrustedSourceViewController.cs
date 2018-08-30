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
    public class AddTrustedSourceViewController : ProjectBaseViewController<AddTrustedSourceViewModel>, IAddTrustedSourceViewController
    {
        IAddTrustedSourceRepository _Reposetory;

        public override void SetRepositories()
        {
            _Reposetory = new AddTrustedSourceRepository(_MasterRepo);
        }

        public void Load()
        {
            InputObject.SourceDetail = _Reposetory.GetTrustedContactDetailFromMaster();
        }

        public void SaveTrustedSource()
        {
            _Reposetory.UpdateMasterWithTrustedSource(InputObject.SourceDetail);
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }
    }
}