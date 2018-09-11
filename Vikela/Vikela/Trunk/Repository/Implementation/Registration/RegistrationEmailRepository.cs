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
    public class RegistrationEmailRepository<T> : ProjectBaseRepository, IRegistrationEmailRepository
    {
        public RegistrationEmailRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }

        public async Task UpdateEmailAsync(RegistrationEmailViewModel model)
        {
            _MasterRepo.DataSource.User.EmailAddress = model.EmailAddress;
            await OfflineStorageRepository.Instance.UpdateRecord(_MasterRepo.DataSource.User);
        }
    }
}