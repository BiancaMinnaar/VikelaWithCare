using Vikela.Implementation.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.Implementation;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.ViewController
{
    public class MyCommunityViewController : ProjectBaseViewController<MyCommunityViewModel>, IMyCommunityViewController
    {
        IMyCommunityRepository _Reposetory;
        IDynamixReturnService<DynamixCommunity> _Service;

        public override void SetRepositories()
        {
            _Service =  new DynamixReturnService<DynamixCommunity>((U, P, A) =>
                                                 ExecuteQueryWithReturnTypeAndNetworkAccessAsync<DynamixCommunity>(U, P, A));
            _Reposetory = new MyCommunityRepository(_MasterRepo, _Service);
        }

        public void LoadCommunity()
        {
            InputObject = _Reposetory.GetCommunityFromMaster();
        }
    }
}