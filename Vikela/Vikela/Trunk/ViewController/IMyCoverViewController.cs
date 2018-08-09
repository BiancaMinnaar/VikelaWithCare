using System;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Interface.ViewController
{
    public interface IMyCoverViewController
    {
        void Load();
        void PushEditProfile();
        PersonalDetailViewModel GetPersonalDetailTileViewModel(Action OnClick);
        TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action OnClick);
        SiyabongaViewModel GetSiyabongaTileViewModel(Action OnClick);
        ActiveCoverViewModel GetActiveCoverTileViewModel(Action OnLick);
    }
}
