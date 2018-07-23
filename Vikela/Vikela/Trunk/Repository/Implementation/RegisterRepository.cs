using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class RegisterRepository<T> : ProjectBaseRepository, IRegisterRepository<T>
        where T : BaseViewModel
    {
        IRegisterService<T> _Service;

        public RegisterRepository(IMasterRepository masterRepository, IRegisterService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Register(RegisterViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Register(model);
            completeAction(serviceReturnModel);
        }
    }
}