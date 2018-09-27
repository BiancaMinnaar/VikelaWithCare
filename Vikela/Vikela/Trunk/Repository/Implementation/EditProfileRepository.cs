using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Implementation.Repository
{
    public class EditProfileRepository<T> : ProjectBaseRepository, IEditProfileRepository<T>
        where T : BaseViewModel
    {
        public EditProfileRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
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
    }
}