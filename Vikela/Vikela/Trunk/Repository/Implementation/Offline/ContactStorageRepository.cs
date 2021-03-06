﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Vikela.Interface.Repository;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository.Implementation.Offline
{
    public class ContactStorageRepository : BaseStorageRepository<ContactModel>, IContactStorageRepository
    {
        internal string ID;
        protected string SelectWithIDQuery { get; private set; }
        internal const string TrustedSourceRoleName = "Trusted Friend";
        protected string SelectTrustedSources { get; private set; }
        internal const string DefaultBeneficiaryRoleName = "Beneficiary";
        protected string SelectDefaultBeneficiary { get; private set; }

        public ContactStorageRepository(IMasterRepository masterRepository, IOfflineStorageRepository offlineStorageRepo)
            : base(masterRepository, offlineStorageRepo)
        {
            SelectTrustedSources = $"SELECT * FROM ContactModel where ContactRole = '{TrustedSourceRoleName}'";
            SelectDefaultBeneficiary = $"SELECT * FROM ContactModel where ContactRole = '{DefaultBeneficiaryRoleName}'";

        }

        public async Task<ContactModel> GetContactWithIDAsync(ContactModel model)
        {
            ID = model.Id.ToString();
            SelectWithIDQuery = $"SELECT * FROM ContactModel where UserID = {ID}";
            var list = await OfflineStorageRepo.QueryTableAsync<ContactModel>(
                SelectWithIDQuery);
            if (list != null && list.Count > 0)
                return list[0];
            return null;
        }

        public async Task SaveContactToLocalStorageAsync(ContactModel model)
        {
            var returnedModel = await GetContactWithIDAsync(model);
            if (returnedModel != null)
            {
                model.Id = returnedModel.Id;
                var affected = await OfflineStorageRepo.UpdateRecordAsync(model);
                var whatIsAff = affected;
            }
            else
            {
                await OfflineStorageRepo.InsertRecordAsync(model);
            }
        }

        public async Task SaveContactListToLocalStorageAsync(List<ContactModel> modelList)
        {
            foreach (ContactModel model in modelList)
                await SaveContactToLocalStorageAsync(model);
        }

        public async Task<List<ContactModel>> GetTrustedSourcesAsync()
        {
            return await OfflineStorageRepo.QueryTableAsync<ContactModel>(SelectTrustedSources);
        }

        public async Task<ContactModel> GetDefaultBeneficiaryAsync()
        {
            var Beneficiaries = await OfflineStorageRepo.QueryTableAsync<ContactModel>(SelectDefaultBeneficiary);
            if (Beneficiaries != null && Beneficiaries.Count > 0)
                return Beneficiaries[0];
            return null;
        }
    }
}
