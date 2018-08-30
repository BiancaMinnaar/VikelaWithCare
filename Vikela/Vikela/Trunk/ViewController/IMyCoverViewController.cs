using System;
using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Interface.ViewController
{
    public interface IMyCoverViewController
    {
        void Load();
        void PushEditProfile();
        void PushAddBeneficiary();
        PersonalDetailViewModel GetPersonalDetailTileViewModel(Action OnClick);
        TrustedSourcesViewModel GetTrustedSourcesTileViewModel(Action<object> OnClick);
        SiyabongaViewModel GetSiyabongaTileViewModel(Action OnClick);
        ActiveCoverViewModel GetActiveCoverTileViewModel(Action OnLick);
		Task RegisterAsync();
    }
}
