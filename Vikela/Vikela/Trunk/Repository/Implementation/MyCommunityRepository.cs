using System.Threading.Tasks;
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
        IDynamixService _DynamixService;

        public MyCommunityRepository(IMasterRepository masterRepository, IDynamixReturnService<DynamixCommunity> service, 
                                     IDynamixService dynservice)
            : base(masterRepository)
        {
            _Service = service;
            _DynamixService = dynservice;
        }

        public MyCommunityViewModel GetCommunityFromMaster()
        {
            var source = _MasterRepo.DataSource.Community;
            return new MyCommunityViewModel
            {
                CommunityName = source.CommunityName
            };
        }

        public async Task SaveCommunityAsync(MyCommunityViewModel model)
        {
            await _DynamixService.UpdateCommunityAsync(model);
        }

        public async Task UpdateMasterWithCommunityAsync(MyCommunityViewModel model)
        {
            var source = _MasterRepo.DataSource.Community;
            source.CommunityName = model.CommunityName;
            await _MasterRepo.SaveCommunityAsync(source);
        }
    }
}