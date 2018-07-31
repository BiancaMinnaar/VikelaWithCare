using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class RegistrationVerifyMobileRepository<T> : ProjectBaseRepository, IRegistrationVerifyMobileRepository<T>
        where T : BaseViewModel
    {
        IRegistrationVerifyMobileService<T> _Service;

        public RegistrationVerifyMobileRepository(IMasterRepository masterRepository, IRegistrationVerifyMobileService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task UpdateOTP(RegistrationVerifyMobileViewModel model, Action<RegistrationVerifyMobileViewModel> completeAction)
        {
            completeAction(model);
        }
    }
}