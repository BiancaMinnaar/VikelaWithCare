using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.Implementation;

namespace Vikela.Implementation.ViewController
{
    public class AddTrustedSourceViewController : ProjectBaseViewController<AddContactViewModel>, IAddTrustedSourceViewController
    {
        IAddTrustedSourceRepository _Reposetory;
        IDynamixService _service;

        public override void SetRepositories()
        {
            _service = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _Reposetory = new AddTrustedSourceRepository(_MasterRepo, _service);
        }

        public void LoadTrustedSources()
        {
            InputObject.SourceDetail = _Reposetory.GetTrustedContactDetailFromMaster();
        }

        public async Task SaveTrustedSourceAsync()
        {
            await _Reposetory.SaveTrustedContactAsync(InputObject);
            _Reposetory.UpdateMasterWithTrustedSource(InputObject.SourceDetail);
        }

		public void SaveBenificiary()
		{
            _Reposetory.UpdateMasterWithBeneficiary(InputObject.SourceDetail);
		}

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }

        public void LoadBeneficiary()
        {
            InputObject.SourceDetail = _Reposetory.GetDefaultBeneniciaryFromMaster();
        }
    }
}