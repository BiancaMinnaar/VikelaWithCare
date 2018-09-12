using System.Collections.Generic;
using System.Threading.Tasks;
using Vikela.Interface.Repository;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository.Implementation.Offline
{
    public class ContactStorageRepository : BaseStorageRepository<ContactModel>, IContactStorageRepository
    {
        internal string ID;
        protected string SelectWithIDQuery { get; private set; }
        internal const string TrustedSourceRoleName = "Trusted Source";
        protected string SelectTrustedSources { get; private set; }
        internal const string DefaultBeneficiaryRoleName = "Beneficiary";
        protected string SelectDefaultBeneficiary { get; private set; }

        public ContactStorageRepository(IMasterRepository masterRepository, IOfflineStorageRepository offlineStorageRepo)
            : base(masterRepository, offlineStorageRepo)
        {
            SelectWithIDQuery = $"SELECT * FROM ContactModel where Id = {ID}";
            SelectTrustedSources = $"SELECT * FROM ContactModel where ContactRole = '{TrustedSourceRoleName}'";
            SelectDefaultBeneficiary = $"SELECT * FROM ContactModel where ContactRole = '{DefaultBeneficiaryRoleName}'";

        }

        public async Task<ContactModel> GetContactWithIDAsync(ContactModel model)
        {
            ID = model.Id.ToString();
            var list = await OfflineStorageRepo.QueryTable<ContactModel>(
                SelectWithIDQuery);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public async Task SaveContactToLocalStorageAsync(ContactModel model)
        {
            await GetContactWithIDAsync(model);
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

        public async Task<List<ContactModel>> GetTrustedSourcesAsync()
        {
            return await OfflineStorageRepo.QueryTable<ContactModel>(SelectTrustedSources);
        }

        public async Task<ContactModel> GetDefaultBeneficiaryAsync()
        {
            var Beneficiaries = await OfflineStorageRepo.QueryTable<ContactModel>(SelectDefaultBeneficiary);
            if (Beneficiaries != null && Beneficiaries.Count > 0)
                return Beneficiaries[0];
            return null;
        }
    }
}
