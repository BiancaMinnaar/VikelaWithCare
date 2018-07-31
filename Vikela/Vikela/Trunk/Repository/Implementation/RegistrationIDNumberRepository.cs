using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class RegistrationIDNumberRepository<T> : ProjectBaseRepository, IRegistrationIDNumberRepository<T>
        where T : BaseViewModel
    {
        IRegistrationIDNumberService<T> _Service;

        public RegistrationIDNumberRepository(IMasterRepository masterRepository, IRegistrationIDNumberService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task UpdateIDNumber(RegistrationIDNumberViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.UpdateIDNumber(model);
            completeAction(serviceReturnModel);
        }
    }
}