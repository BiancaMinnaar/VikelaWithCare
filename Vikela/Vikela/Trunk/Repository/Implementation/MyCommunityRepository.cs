using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.Repository
{
    public class MyCommunityRepository : ProjectBaseRepository, IMyCommunityRepository
    {
        IDynamixReturnService<DynamixCommunity> _Service;

        public MyCommunityRepository(IMasterRepository masterRepository, IDynamixReturnService<DynamixCommunity> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public MyCommunityViewModel GetCommunityFromMaster()
        {
            var source = _MasterRepo.DataSource.Community;
            return new MyCommunityViewModel
            {
                CommunityName = source.CommunityName
            };
        }
    }
}