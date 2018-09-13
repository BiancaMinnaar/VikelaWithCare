using System;
using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.Implementation;
using Vikela.Trunk.Service.ReturnModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Implementation.ViewController
{
    public class MyCommunityViewController : ProjectBaseViewController<MyCommunityViewModel>, IMyCommunityViewController
    {
        IMyCommunityRepository _Reposetory;
        IDynamixReturnService<DynamixCommunity> _Service;
        IDynamixService _service;
        IMyCoverRepository<MyCoverViewModel> CoverRepo;

        public override void SetRepositories()
        {
            _Service =  new DynamixReturnService<DynamixCommunity>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<DynamixCommunity>(U, P, A));
            _service = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _Reposetory = new MyCommunityRepository(_MasterRepo, _Service, _service);
            CoverRepo = new MyCoverRepository<MyCoverViewModel>(_MasterRepo);
        }

        public void LoadCommunity()
        {
            InputObject = _Reposetory.GetCommunityFromMaster();
        }

        public TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action<object> OnClick)
        {
            return CoverRepo.GetTrustedSourcesTileViewModel(OnClick);
        }

        public void PopToCover()
        {
            _MasterRepo.PopView();
        }

        public async Task SaveCommunityAsync()
        {
            InputObject.TokenID = _MasterRepo.DataSource.User.TokenID;
            InputObject.UserID = _MasterRepo.DataSource.User.UserID;
            await _Reposetory.SaveCommunityAsync(InputObject);
            await _Reposetory.UpdateMasterWithCommunityAsync(InputObject);
        }
    }
}