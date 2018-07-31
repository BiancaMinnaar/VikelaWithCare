using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class RegistrationCellphoneRepository<T> : ProjectBaseRepository, IRegistrationCellphoneRepository<T>
        where T : BaseViewModel
    {
        IRegistrationCellphoneService<T> _Service;

        public RegistrationCellphoneRepository(IMasterRepository masterRepository, IRegistrationCellphoneService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task UpdateCellPhone(RegistrationCellphoneViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.UpdateCellPhone(model);
            completeAction(serviceReturnModel);
        }
    }
}