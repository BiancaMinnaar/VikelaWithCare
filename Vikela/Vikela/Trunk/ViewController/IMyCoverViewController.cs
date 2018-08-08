using System;
using Vikela.Implementation.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Interface.ViewController
{
    public interface IMyCoverViewController
    {
        void Load();
        void PushEditProfile();
        PersonalDetailViewModel GetPersonalDetailTile(Action OnClick);
        SiyabongaViewModel GetSiyabongaTile(Action OnClick);
    }
}
