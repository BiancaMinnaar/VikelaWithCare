using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Trunk.Service.ReturnModel;

namespace Vikela.Implementation.Repository
{
    public class NIUSSDRepository : ProjectBaseRepository, INIUSSDRepository
    {
        INIUSSDService<NIUSSDReturnModel> _Service;

        public NIUSSDRepository(IMasterRepository masterRepository, INIUSSDService<NIUSSDReturnModel> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task SendUSSDAsync(NIUSSDViewModel model, Action completeAction)
        {
            await _Service.SendUSSDAsync(model);
            completeAction();
        }
    }
}