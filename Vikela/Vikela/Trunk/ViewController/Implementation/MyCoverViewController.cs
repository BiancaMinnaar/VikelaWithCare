using System;
using System.Threading.Tasks;
using Vikela.Implementation.Repository;
using Vikela.Implementation.Service;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Interface.ViewController;
using Vikela.Root.ViewController;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Implementation.ViewController
{
    public class MyCoverViewController : ProjectBaseViewController<MyCoverViewModel>, IMyCoverViewController
    {
        IMyCoverRepository<MyCoverViewModel> _Reposetory;
        IMyCoverService<MyCoverViewModel> _Service;
        IRegisterService<RegisterViewModel> _RegisterService;
        IRegisterRepository<RegisterViewModel> _RegisterRepo;

        public override void SetRepositories()
        {
            _Service = new MyCoverService<MyCoverViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<MyCoverViewModel>(U, P, C, A));
            _Reposetory = new MyCoverRepository<MyCoverViewModel>(_MasterRepo, _Service);
            _RegisterService = new RegisterService<RegisterViewModel>((U, P, C, A) =>
                                                                     ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegisterViewModel>(U, P, C, A));
            _RegisterRepo = new RegisterRepository<RegisterViewModel>(_MasterRepo, _RegisterService);
        }

        public void Load()
        {
            _Reposetory.Load(InputObject);
        }

        public void PushEditProfile()
        {
            _MasterRepo.PushEditProfile();
        }

        public PersonalDetailViewModel GetPersonalDetailTileViewModel(Action OnClick)
        {
            return _Reposetory.GetPersonalDetailTileViewModel(OnClick);
        }

        public TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action OnClick)
        {
            return _Reposetory.GetTrustedSourcesTileViewModel(OnClick);
        }

        public SiyabongaViewModel GetSiyabongaTileViewModel(Action OnClick)
        {
            return _Reposetory.GetSiyabongaTileViewModel(OnClick);
        }

        public ActiveCoverViewModel GetActiveCoverTileViewModel(Action OnLick)
        {
            return _Reposetory.GetActiveCoverTileViewModel(OnLick);
        }

		public async Task RegisterAsync()
		{
            await _RegisterRepo.RegisterWithD365Async(new RegisterViewModel()
            {
                UniqueIdentifier = _MasterRepo.DataSource.User.UniqueIdentifier,
                EmailAddress = "Edit@email.com",
                FirstName = _MasterRepo.DataSource.User.FirstName,
                IDNumber = "Edit",
                LastName = "Edit",
                MobileNumber = _MasterRepo.DataSource.User.MobileNumber,
                OID = _MasterRepo.DataSource.User.OID,
                UserPictureURL = "Edit",
                TokenID = _MasterRepo.DataSource.User.TokenID
            });
		}
    }
}