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
        IEditProfileService<T> _Service;

        public EditProfileRepository(IMasterRepository masterRepository, IEditProfileService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Edit(EditProfileViewModel model, Action<T> completeAction)
        {
            var serviceReturnModel = await _Service.Edit(model);
            completeAction(serviceReturnModel);
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