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
        public RegistrationVerifyMobileRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }

        public async Task UpdateOTPAsync(RegistrationVerifyMobileViewModel model)
        {
            //TODO:Implement
        }
    }
}