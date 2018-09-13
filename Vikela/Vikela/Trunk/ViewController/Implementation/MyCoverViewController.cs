using System;
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
using System.Collections.Generic;

namespace Vikela.Implementation.ViewController
{
    public class MyCoverViewController : ProjectBaseViewController<MyCoverViewModel>, IMyCoverViewController
    {
        IMyCoverRepository<MyCoverViewModel> _Reposetory;
        IRegisterService _RegisterService;
        IRegisterRepository _RegisterRepo;
		IDynamixService _DynamixService;

        public override void SetRepositories()
        {
            _Reposetory = new MyCoverRepository<MyCoverViewModel>(_MasterRepo);
            _RegisterService = new RegisterService((U, P, A) =>
                                                   ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _DynamixService = new DynamixService((U, P, A) =>
                                                 ExecuteQueryWithTypedParametersAndNetworkAccessAsync(U, P, A));
            _RegisterRepo = new RegisterRepository(_MasterRepo, _RegisterService, _DynamixService);
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

        public List<ActiveCoverViewModel> GetActiveCoverTileModels(Action OnLick)
        {
            return _Reposetory.GetActiveCoverTileModels(OnLick);
        }
    }
}