using System;
using System.Threading.Tasks;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
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
            return new ProfileModel()
            {
                FirstName = _MasterRepo.DataSource.User.FirstName,
                UserImage = _MasterRepo.DataSource.User.UserPicture,
                LastName = _MasterRepo.DataSource.User.LastName
            };
        }
    }
}