using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class ContactDetailViewRepository<T> : ProjectBaseRepository, IContactDetailViewRepository<T>
        where T : BaseViewModel
    {
        IContactDetailViewService<T> _Service;

        public ContactDetailViewRepository(IMasterRepository masterRepository, IContactDetailViewService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Load(ContactDetailViewViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Load(model);
            completeAction(serviceReturnModel);
        }
    }
}