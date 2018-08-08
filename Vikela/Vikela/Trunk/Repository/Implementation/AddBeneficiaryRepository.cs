using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class AddBeneficiaryRepository<T> : ProjectBaseRepository, IAddBeneficiaryRepository<T>
        where T : BaseViewModel
    {
        IAddBeneficiaryService<T> _Service;

        public AddBeneficiaryRepository(IMasterRepository masterRepository, IAddBeneficiaryService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Save(AddBeneficiaryViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Save(model);
            completeAction(serviceReturnModel);
        }
    }
}