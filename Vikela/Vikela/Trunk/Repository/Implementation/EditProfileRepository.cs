using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.Service;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Implementation.Repository
{
    public class EditProfileRepository<T> : ProjectBaseRepository, IEditProfileRepository<T>
        where T : BaseViewModel
    {
        IDynamixService _DynamixService;

        public EditProfileRepository(IMasterRepository masterRepository, IDynamixService UserService)
            : base(masterRepository)
        {
            _DynamixService = UserService;
        }

        public UserModel GetUserModelToUpdate(ProfileModel model)
        {
            var user = _MasterRepo.DataSource.User;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.MobileNumber = model.CellPhoneNumber;
            user.UserPicture = model.UserImage.Selfie;
            return user;
        }

        public ProfileModel Load()
        {
            return new ProfileModel
            {
                FirstName = _MasterRepo.DataSource.User.FirstName,
                LastName = _MasterRepo.DataSource.User.LastName,
                CellPhoneNumber = _MasterRepo.DataSource.User.MobileNumber,
                UserImage = new SelfieViewModel { Selfie = _MasterRepo.DataSource.User.UserPicture }
            };
        }

        public async Task SaveUserAsync(ContactDetailViewModel model)
        {
            await _DynamixService.UpdateContactAsync(model);
        }

        public ContactDetailViewModel GetUserContactModelFromMaster()
        {
            if (_MasterRepo.DataSource.User != null)
            {
                var source = _MasterRepo.DataSource.User;
                return new ContactDetailViewModel()
                {
                    UserID = source.UserID,
                    FirstName = source.FirstName,
                    LastName = source.LastName,
                    CellNumber = source.MobileNumber,
                    IDNumber = source.IDNumber,
                    Email = source.EmailAddress,
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
    }
}