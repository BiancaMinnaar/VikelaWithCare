using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.ReturnModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Implementation.Repository
{
    public class AddTrustedSourceRepository : ProjectBaseRepository, IAddTrustedSourceRepository
    {
		IDynamixService _DynamixService;
        IDynamixReturnService<DynamicTrustedSourceAddReturn> _DynamixReturnService;
        public AddTrustedSourceRepository(IMasterRepository masterRepository, IDynamixService service, 
		                                  IDynamixReturnService<DynamicTrustedSourceAddReturn> dynamixReturnService)
            : base(masterRepository)
        {
			_DynamixReturnService = dynamixReturnService;
			_DynamixService = service;
        }

        public ContactDetailViewModel GetTrustedContactDetailFromMaster()
        {
            if (_MasterRepo.DataSource.TrustedSources != null 
                && _MasterRepo.DataSource.TrustedSources.Count > _MasterRepo.DataSource.TrustedSourceEditIndex)
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
            return new ContactDetailViewModel()
            {
                ContactPicture = new SelfieViewModel
                {
                },
                TokenID = _MasterRepo.DataSource.User.TokenID
            };
        }

        public async Task SaveTrustedSourceAsync(ContactDetailViewModel model)
        {
            if (model.UserID == null)
            {
                model.TokenID = _MasterRepo.DataSource.User.TokenID;
                model.UserID = _MasterRepo.DataSource.User.UserID;
                var mo = await _DynamixReturnService.AddTrustedSourceAsync(model);
                model.UserID = mo.body.trusteeUserId;
            }
            else
            {
                await _DynamixService.UpdateContactAsync(model);
            }
        }

        public async Task UpdateMasterWithTrustedSourceAsync(ContactDetailViewModel model)
        {
            ContactModel contactModel;
            if (_MasterRepo.DataSource.TrustedSources.Count > _MasterRepo.DataSource.TrustedSourceEditIndex)
            {
                contactModel = _MasterRepo.DataSource.TrustedSources[_MasterRepo.DataSource.TrustedSourceEditIndex];
            }
            else
            {
                contactModel = new ContactModel();
                _MasterRepo.DataSource.TrustedSources.Add(contactModel);
            }
            contactModel.UserPicture = model.ContactPicture.Selfie;
            contactModel.FirstName = model.FirstName;
            contactModel.LastName = model.LastName;
            contactModel.CellNumber = model.CellNumber;
            contactModel.IDNumber = model.IDNumber;
            contactModel.Email = model.Email;
            contactModel.UserPicture = model.ContactPicture.Selfie;
            await _MasterRepo.SaveTrustedSourceAsync(contactModel, _MasterRepo.DataSource.TrustedSourceEditIndex);
            _MasterRepo.DataSource.TrustedSourceEditIndex = -1;
        }
    }
}