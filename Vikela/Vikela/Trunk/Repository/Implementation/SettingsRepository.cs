using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class SettingsRepository<T> : ProjectBaseRepository, ISettingsRepository<T>
        where T : BaseViewModel
    {
        ISettingsService<T> _Service;

        public SettingsRepository(IMasterRepository masterRepository, ISettingsService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Show(SettingsViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Show(model);
            completeAction(serviceReturnModel);
        }
    }
}