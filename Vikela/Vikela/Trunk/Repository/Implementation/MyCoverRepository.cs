using System;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Xamarin.Forms;

namespace Vikela.Implementation.Repository
{
    public class MyCoverRepository<T> : ProjectBaseRepository, IMyCoverRepository<T>
        where T : BaseViewModel
    {
        IMyCoverService<T> _Service;

        public MyCoverRepository(IMasterRepository masterRepository, IMyCoverService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public void Load(MyCoverViewModel model)
        {
            model.UserProfile = new Trunk.ViewModel.ProfileModel()
            {
                FirstName = _MasterRepo.DataSource.User.FirstName,
                UserImage = _MasterRepo.DataSource.User.UserPicture,
                LastName = _MasterRepo.DataSource.User.LastName
            };
        }

        public PersonalDetailViewModel GetPersonalDetailTile(Action OnCLick)
        {
            return new PersonalDetailViewModel()
            {
                Index = 0,
                Profile = new Trunk.ViewModel.ProfileModel
                {
                    UserImage = _MasterRepo.DataSource.User.UserPicture,
                    FirstName = _MasterRepo.DataSource.User.FirstName,
                    LastName = _MasterRepo.DataSource.User.LastName
                },
                ItemClickedCommand = new Command(OnCLick)
            };
        }
    }
}