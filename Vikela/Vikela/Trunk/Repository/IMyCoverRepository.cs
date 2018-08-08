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
        PersonalDetailViewModel GetPersonalDetailTile(Action OnClick);
        TrustedSourcesViewModel GetTrustedSourcesTile(Action OnClick);
        SiyabongaViewModel GetSiyabongaTile(Action OnClick);
    }
}
