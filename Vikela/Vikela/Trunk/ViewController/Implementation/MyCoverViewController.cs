using System;
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

        public override void SetRepositories()
        {
            _Service = new MyCoverService<MyCoverViewModel>((U, P, C, A) => 
                                                           ExecuteQueryWithReturnTypeAndNetworkAccessAsync<MyCoverViewModel>(U, P, C, A));
            _Reposetory = new MyCoverRepository<MyCoverViewModel>(_MasterRepo, _Service);
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
    }
}