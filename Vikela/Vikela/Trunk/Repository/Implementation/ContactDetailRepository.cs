using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class ContactDetailRepository<T> : ProjectBaseRepository, IContactDetailRepository<T>
        where T : BaseViewModel
    {
        IContactDetailService<T> _Service;

        public ContactDetailRepository(IMasterRepository masterRepository, IContactDetailService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Load(ContactDetailViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Load(model);
            completeAction(serviceReturnModel);
        }
    }
}