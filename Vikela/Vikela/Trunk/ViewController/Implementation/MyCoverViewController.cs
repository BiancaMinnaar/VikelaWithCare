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
using Vikela.Trunk.Service;
using Vikela.Trunk.Service.Implementation;

namespace Vikela.Implementation.ViewController
{
    public class MyCoverViewController : ProjectBaseViewController<MyCoverViewModel>, IMyCoverViewController
    {
        IMyCoverRepository<MyCoverViewModel> _Reposetory;
        IMyCoverService<MyCoverViewModel> _Service;
        IRegisterService<RegisterViewModel> _RegisterService;
        IRegisterRepository<RegisterViewModel> _RegisterRepo;
		IDynamixService _DynamixService;

        public override void SetRepositories()
        {
            _Service = new MyCoverService<MyCoverViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<MyCoverViewModel>(U, P, C, A));
            _Reposetory = new MyCoverRepository<MyCoverViewModel>(_MasterRepo, _Service);
            _RegisterService = new RegisterService<RegisterViewModel>((U, P, C, A) =>
                                                                     ExecuteQueryWithReturnTypeAndNetworkAccessAsync<RegisterViewModel>(U, P, C, A));
            _DynamixService = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _RegisterRepo = new RegisterRepository<RegisterViewModel>(_MasterRepo, _RegisterService, _DynamixService);
        }

        public void Load(Action detailClick, Action<object> trustedSourcesClick)
        {
            _Reposetory.Load(InputObject, detailClick, trustedSourcesClick);
        }

        public void PushEditProfile()
        {
            _MasterRepo.PushEditProfile();
        }

        public void  PushAddBeneficiary()
        {
            _MasterRepo.PushAddBeneficiary();
        }

        public PersonalDetailViewModel GetPersonalDetailTileViewModel(Action OnClick)
        {
            return _Reposetory.GetPersonalDetailTileViewModel(OnClick);
        }

        public TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action<object> OnClick)
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

		//TODO:Remove, only for testing
		public async Task RegisterAsync()
		{
            var registerData = new RegisterViewModel
            {
                EmailAddress = _MasterRepo.DataSource.User.EmailAddress,
                FirstName = _MasterRepo.DataSource.User.FirstName,
                IDNumber = _MasterRepo.DataSource.User.IDNumber,
                LastName = _MasterRepo.DataSource.User.LastName,
                MobileNumber = _MasterRepo.DataSource.User.MobileNumber,
                OID = _MasterRepo.DataSource.User.OID,
                UserPictureURL = "Edit",
                TokenID = _MasterRepo.DataSource.User.TokenID
            };
			var errors = await _RegisterRepo.RegisterWithD365Async(registerData);
			if (errors[0] != "Success")
			{
				foreach(var message in errors)
					ShowMessage(message);
            }
            else
                ShowMessage(_ResponseContent);
		}
    }
}