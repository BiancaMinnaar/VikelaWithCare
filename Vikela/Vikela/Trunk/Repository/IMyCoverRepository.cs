using System;
using CorePCL;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IMyCoverRepository<T>
        where T : BaseViewModel
    {
        void Load(MyCoverViewModel model);
        PersonalDetailViewModel GetPersonalDetailTile(Action OnClick);
    }
}
