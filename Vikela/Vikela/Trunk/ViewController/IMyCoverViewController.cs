using System;
using System.Collections.Generic;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Interface.ViewController
{
    public interface IMyCoverViewController
    {
        void Load(Action detailClick, Action<object> trustedSourcesClick);
        void PushEditProfile();
        void PushAddBeneficiary();
        PersonalDetailViewModel GetPersonalDetailTileViewModel(Action OnClick);
        TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action<object> OnClick);
        SiyabongaViewModel GetSiyabongaTileViewModel(Action OnClick);
        List<ActiveCoverViewModel> GetActiveCoverTileModels(Action OnLick);
    }
}
