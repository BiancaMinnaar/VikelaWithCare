using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class MyCommunityRepository<T> : ProjectBaseRepository, IMyCommunityRepository<T>
        where T : BaseViewModel
    {
        IMyCommunityService<T> _Service;

        public MyCommunityRepository(IMasterRepository masterRepository, IMyCommunityService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Load(MyCommunityViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Load(model);
            completeAction(serviceReturnModel);
        }
    }
}