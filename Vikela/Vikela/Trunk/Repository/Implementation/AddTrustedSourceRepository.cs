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
                UserID = source.UserID,
                FirstName = source.FirstName,
                LastName = source.LastName,
                CellNumber = source.CellNumber,
                IDNumber = source.IDNumber,
                Email = source.Email,
                ContactPicture = new SelfieViewModel
                {
                    Selfie = source.UserPicture
                },
                TokenID = _MasterRepo.DataSource.User.TokenID
            };
        }

		public async Task SaveTrustedContactAsync(ContactDetailViewModel model)
		{
            await _DynamixService.UpdateContactAsync(model);
        }

        public ContactDetailViewModel GetDefaultBeneniciaryFromMaster()
        {
            var source = _MasterRepo.DataSource.DefaultBeneficiary;
            return new ContactDetailViewModel()
            {
                UserID = source.UserID,
                FirstName = source.FirstName,
                LastName = source.LastName,
                CellNumber = source.CellNumber,
                IDNumber = source.IDNumber,
                Email = source.Email,
                ContactPicture = new SelfieViewModel
                {
                    Selfie = source.UserPicture
                },
                TokenID = _MasterRepo.DataSource.User.TokenID
            };
        }

        public async Task SaveDefaultBeneficiaryAsync(ContactDetailViewModel model)
        {
            await _DynamixService.UpdateContactAsync(model);
        }

        public async Task SaveTrustedSourceAsync(ContactDetailViewModel model)
        {
            await _DynamixService.UpdateContactAsync(model);
        }

        public async Task UpdateMasterWithTrustedSourceAsync(ContactDetailViewModel model)
        {
            var source = _MasterRepo.DataSource.TrustedSources[_MasterRepo.DataSource.TrustedSourceEditIndex];
            source.UserPicture = model.ContactPicture.Selfie;
            source.FirstName = model.FirstName;
            source.LastName = model.LastName;
            source.CellNumber = model.CellNumber;
            source.IDNumber = model.IDNumber;
            source.Email = model.Email;
            await _MasterRepo.SaveTrustedSourceAsync(source, _MasterRepo.DataSource.TrustedSourceEditIndex);
            _MasterRepo.DataSource.TrustedSourceEditIndex = -1;
        }

        public async Task UpdateMasterWithBeneficiaryAsync(ContactDetailViewModel model)
        {
            var source = _MasterRepo.DataSource.DefaultBeneficiary;
            source.UserPicture = model.ContactPicture.Selfie;
            source.FirstName = model.FirstName;
            source.LastName = model.LastName;
            source.CellNumber = model.CellNumber;
            source.IDNumber = model.IDNumber;
            source.Email = model.Email;
            await _MasterRepo.SaveBeneficiaryAsync(source);
        }
    }
}