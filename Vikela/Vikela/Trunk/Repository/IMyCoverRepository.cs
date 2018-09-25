using System;
using System.Collections.Generic;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Interface.Repository
{
    public interface IMyCoverRepository<T>
        where T : BaseViewModel
    {
        void Load(MyCoverViewModel model, Action detailClick, Action<object> trustedSourcesClic);
        PersonalDetailViewModel GetPersonalDetailTileViewModel(Action OnClick);
        TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action<object> OnClick);
        SiyabongaViewModel GetSiyabongaTileViewModel(Action OnClick);
        List<ActiveCoverViewModel> GetActiveCoverTileModels(Action<object> OnLick);
    }
}
