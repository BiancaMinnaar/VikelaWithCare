using System.Threading.Tasks;
using Vikela.Interface.Repository;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository.Implementation.Offline
{
    public class ContactStorageRepository : BaseStorageRepository<ContactModel>, IContactStorageRepository
    {
        private string ID;
        protected string SelectWithIDQuery { get; private set; }
        private const string TrustedSourceRoleName = "Trusted Source";
        protected string SelectTrustedSources { get; private set; }
        private const string DefaultBeneficiaryRoleName = "Beneficiary";
        protected string SelectDefaultBeneficiary { get; private set; }

        public ContactStorageRepository(IMasterRepository masterRepository, IOfflineStorageRepository offlineStorageRepo)
            : base(masterRepository, offlineStorageRepo)
        {
            SelectWithIDQuery = $"SELECT * FROM ContactModel where Id = {ID}";
            SelectTrustedSources = $"SELECT * FROM ContactModel where ContactRole = '{TrustedSourceRoleName}'";
            SelectTrustedSources = $"SELECT * FROM ContactModel where ContactRole = '{DefaultBeneficiaryRoleName}'";
        }

        public async Task GetContactWithID(ContactModel model)
        {
            ID = model.Id.ToString();
            var list = await OfflineStorageRepo.QueryTable<ContactModel>(
                SelectWithIDQuery);
            if (list != null && list.Count > 0)
                model = list[0];
            model = null;
        }

        public async Task SaveContactToLocalStorage(ContactModel model)
        {
            await CheckCreateModelTable();
            await GetContactWithID(model);
            if (model != null)
            {
                var affected = await OfflineStorageRepo.UpdateRecord(model);
                var whatIsAff = affected;
            }
            else
            {
                await OfflineStorageRepo.InsertRecord(model);
            }
        }
    }
}
