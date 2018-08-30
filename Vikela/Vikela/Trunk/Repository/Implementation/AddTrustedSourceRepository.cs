using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class AddTrustedSourceRepository : ProjectBaseRepository, IAddTrustedSourceRepository
    {

        public AddTrustedSourceRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }

        public ContactDetailViewModel GetTrustedContactDetailFromMaster()
        {
            var source = _MasterRepo.DataSource.TrustedSources[_MasterRepo.DataSource.TrustedSourceEditIndex];
            return new ContactDetailViewModel()
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                CellNumber = source.CellNumber,
                IDNumber = source.IDNumber
            };
        }

        public void UpdateMasterWithTrustedSource(ContactDetailViewModel model)
        {
            var source = _MasterRepo.DataSource.TrustedSources[_MasterRepo.DataSource.TrustedSourceEditIndex];
            source.FirstName = model.FirstName;
            source.LastName = model.LastName;
            source.CellNumber = model.CellNumber;
            source.IDNumber = model.IDNumber;
            _MasterRepo.SaveTrustedSource(source, _MasterRepo.DataSource.TrustedSourceEditIndex);
            _MasterRepo.DataSource.TrustedSourceEditIndex = -1;
        }
    }
}