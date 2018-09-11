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
                UserID = _MasterRepo.DataSource.User.UserID,
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

		public async Task SaveTrustedContactAsync(ContactDetailViewModel model)
		{
			await _DynamixService.AddTrustedSourceAsync(model);
		}

        public ContactDetailViewModel GetDefaultBeneniciaryFromMaster()
        {
            var source = _MasterRepo.DataSource.DefaultBeneficiary;
            return new ContactDetailViewModel()
            {
                UserID = _MasterRepo.DataSource.User.UserID,
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

        public async Task SaveDefaultBeneficiary(ContactDetailViewModel model)
        {
            await _DynamixService.AddBeneficiaryAsync(model);
        }

        public async Task UpdateMasterWithTrustedSource(ContactDetailViewModel model)
        {
            var source = _MasterRepo.DataSource.TrustedSources[_MasterRepo.DataSource.TrustedSourceEditIndex];
            source.UserPicture = model.ContactPicture.Selfie;
            source.FirstName = model.FirstName;
            source.LastName = model.LastName;
            source.CellNumber = model.CellNumber;
            source.IDNumber = model.IDNumber;
            await _MasterRepo.SaveTrustedSourceAsync(source, _MasterRepo.DataSource.TrustedSourceEditIndex);
            _MasterRepo.DataSource.TrustedSourceEditIndex = -1;
        }

        public async Task UpdateMasterWithBeneficiary(ContactDetailViewModel model)
        {
            var source = _MasterRepo.DataSource.DefaultBeneficiary;
            source.UserPicture = model.ContactPicture.Selfie;
            source.FirstName = model.FirstName;
            source.LastName = model.LastName;
            source.CellNumber = model.CellNumber;
            source.IDNumber = model.IDNumber;
            await _MasterRepo.SaveBeneficiaryAsync(source);
        }
    }
}