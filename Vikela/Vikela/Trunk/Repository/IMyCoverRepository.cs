using System;
using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Interface.Repository
{
    public interface IMyCoverRepository<T>
        where T : BaseViewModel
    {
        void Load(MyCoverViewModel model);
        PersonalDetailViewModel GetPersonalDetailTileViewModel(Action OnClick);
        TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action<object> OnClick);
        SiyabongaViewModel GetSiyabongaTileViewModel(Action OnClick);
        ActiveCoverViewModel GetActiveCoverTileViewModel(Action OnLick);
    }
}
