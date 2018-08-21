using System;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;
using Vikela.Trunk.ViewModel.Controlls;
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

        public PersonalDetailViewModel GetPersonalDetailTileViewModel(Action OnCLick)
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

        public TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action OnClick)
        {
            return new TrustedSourcesViewModel()
            {
                Index = 0,

                ItemClickedCommand = new Command(OnClick)
            };
        }

        public SiyabongaViewModel GetSiyabongaTileViewModel(Action OnClick)
        {
            return new SiyabongaViewModel()
            {
                Index = 0,
                TotalBenefits="R750",
                ClaimFreePeriod="9",
                ItemClickedCommand = new Command(OnClick)
            };
        }

        public ActiveCoverViewModel GetActiveCoverTileViewModel(Action OnClick)
        {
            return new ActiveCoverViewModel()
            {
                Index = 0,
                TileColor=Color.FromHex("#BBDE6B"),
                CareAmount="R1500",
                BeneficiaryImage=_MasterRepo.DataSource.User.UserPicture,
                ItemClickedCommand = new Command(OnClick)
            };
        }
    }
}