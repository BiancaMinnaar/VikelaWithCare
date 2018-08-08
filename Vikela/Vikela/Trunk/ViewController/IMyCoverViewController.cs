using System;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.ViewController
{
    public interface IMyCoverViewController
    {
        void Load();
        void PushEditProfile();
        PersonalDetailViewModel GetPersonalDetailTile(Action OnClick); 
    }
}
