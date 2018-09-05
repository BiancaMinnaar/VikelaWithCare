using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.Repository.Implementation;

namespace Vikela.Implementation.Repository
{
    public class RegistrationEmailRepository<T> : ProjectBaseRepository, IRegistrationEmailRepository<T>
        where T : BaseViewModel
    {
        IRegistrationEmailService<T> _Service;

        public RegistrationEmailRepository(IMasterRepository masterRepository, IRegistrationEmailService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task UpdateEmailAsync(RegistrationEmailViewModel model)
        {
            _MasterRepo.DataSource.User.EmailAddress = model.EmailAddress;
            await OfflineStorageRepository.Instance.UpdateRecord(_MasterRepo.DataSource.User);
        }
    }
}