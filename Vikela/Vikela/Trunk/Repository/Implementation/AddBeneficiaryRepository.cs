using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.Repository;
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.ReturnModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Trunk.Repository.Implementation
{
    public class AddBeneficiaryRepository : ProjectBaseRepository, IAddBeneficiaryRepository
    {
        IDynamixService _DynamixService;
        IDynamixReturnService<DynamixBeneficiaryAddReturn> _DynamixReturnService;

        public AddBeneficiaryRepository(IMasterRepository masterRepository, IDynamixService service, 
                                          IDynamixReturnService<DynamixBeneficiaryAddReturn> dynamixReturnService)
            : base(masterRepository)
        {
            _DynamixReturnService = dynamixReturnService;
            _DynamixService = service;
        }

        public ContactDetailViewModel GetDefaultBeneniciaryFromMaster()
        {
            if (_MasterRepo.DataSource.DefaultBeneficiary != null)
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
            return new ContactDetailViewModel()
            {
                ContactPicture = new SelfieViewModel
                {
                },
                TokenID = _MasterRepo.DataSource.User.TokenID
            };
        }

        public async Task SaveDefaultBeneficiaryAsync(ContactDetailViewModel model)
        {
            if(model.UserID == null)
            {
                model.UserID = _MasterRepo.DataSource.User.UserID;
                var mo = await _DynamixReturnService.AddBeneficiaryAsync(model);
                model.UserID = mo.body.benefactorUserId;
            }
            else
            {
                await _DynamixService.UpdateContactAsync(model);
            }
        }

        public async Task UpdateMasterWithBeneficiaryAsync(ContactDetailViewModel model)
        {
            ContactModel contactModel = _MasterRepo.DataSource.DefaultBeneficiary;
            if (contactModel == null)
            {
                contactModel = new ContactModel();
            }
            contactModel.UserPicture = model.ContactPicture.Selfie;
            contactModel.FirstName = model.FirstName;
            contactModel.LastName = model.LastName;
            contactModel.CellNumber = model.CellNumber;
            contactModel.Email = model.Email;
            await _MasterRepo.SaveBeneficiaryAsync(contactModel);
        }
    }
}
