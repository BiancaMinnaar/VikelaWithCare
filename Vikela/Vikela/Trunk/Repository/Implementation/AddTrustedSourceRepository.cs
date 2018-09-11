using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.Service;

namespace Vikela.Implementation.Repository
{
    public class AddTrustedSourceRepository : ProjectBaseRepository, IAddTrustedSourceRepository
    {
		IDynamixService _DynamixService;
        public AddTrustedSourceRepository(IMasterRepository masterRepository, IDynamixService service)
            : base(masterRepository)
        {
			_DynamixService = service;
        }

        public ContactDetailViewModel GetTrustedContactDetailFromMaster()
        {
            var source = _MasterRepo.DataSource.TrustedSources[_MasterRepo.DataSource.TrustedSourceEditIndex];
            return new ContactDetailViewModel()
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                CellNumber = source.CellNumber,
                IDNumber = source.IDNumber,
                ContactPicture = new SelfieViewModel
                {
                    Selfie = source.UserPicture
                },
                TokenID = _MasterRepo.DataSource.User.TokenID
            };
        }

		public async Task SaveTrustedContactAsync(AddContactViewModel model)
		{
			await _DynamixService.AddTrustedSourceAsync(model);
		}

        public ContactDetailViewModel GetDefaultBeneniciaryFromMaster()
        {
            var source = _MasterRepo.DataSource.DefaultBeneficiary;
            return new ContactDetailViewModel()
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                CellNumber = source.CellNumber,
                IDNumber = source.IDNumber,
                ContactPicture = new SelfieViewModel
                {
                    Selfie = source.UserPicture
                }
            };
        }

        public void UpdateMasterWithTrustedSource(ContactDetailViewModel model)
        {
            var source = _MasterRepo.DataSource.TrustedSources[_MasterRepo.DataSource.TrustedSourceEditIndex];
            source.UserPicture = model.ContactPicture.Selfie;
            source.FirstName = model.FirstName;
            source.LastName = model.LastName;
            source.CellNumber = model.CellNumber;
            source.IDNumber = model.IDNumber;
            _MasterRepo.SaveTrustedSource(source, _MasterRepo.DataSource.TrustedSourceEditIndex);
            _MasterRepo.DataSource.TrustedSourceEditIndex = -1;
        }

        public void UpdateMasterWithBeneficiary(ContactDetailViewModel model)
        {
            var source = _MasterRepo.DataSource.DefaultBeneficiary;
            source.UserPicture = model.ContactPicture.Selfie;
            source.FirstName = model.FirstName;
            source.LastName = model.LastName;
            source.CellNumber = model.CellNumber;
            source.IDNumber = model.IDNumber;
            _MasterRepo.SaveBeneficiary(source);
        }
    }
}