using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class ContactDetailRepository : ProjectBaseRepository, IContactDetailRepository
    {
        IAddTrustedSourceRepository _Reposetory;

        public ContactDetailRepository(IMasterRepository masterRepository, IAddTrustedSourceRepository repository)
            : base(masterRepository)
        {
            _Reposetory = repository;
        }

        public void Load(ContactDetailViewModel model)
        {
            model = _Reposetory.GetTrustedContactDetailFromMaster();
        }
    }
}