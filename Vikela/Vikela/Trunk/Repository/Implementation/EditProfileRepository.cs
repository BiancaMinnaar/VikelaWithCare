using CorePCL;
using Vikela.Interface.Repository;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel;

namespace Vikela.Implementation.Repository
{
    public class EditProfileRepository<T> : ProjectBaseRepository, IEditProfileRepository<T>
        where T : BaseViewModel
    {
        public EditProfileRepository(IMasterRepository masterRepository)
            : base(masterRepository)
        {
        }

        public ProfileModel Load()
        {
            return new ProfileModel
            {
                FirstName = _MasterRepo.DataSource.User.FirstName,
                LastName = _MasterRepo.DataSource.User.LastName,
                CellPhoneNumber = _MasterRepo.DataSource.User.MobileNumber,
                UserImage = _MasterRepo.DataSource.User.UserPicture
            };
        }
    }
}