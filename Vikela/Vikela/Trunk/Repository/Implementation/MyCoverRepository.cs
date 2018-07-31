using CorePCL;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;
using Vikela.Root.Repository;

namespace Vikela.Implementation.Repository
{
    public class MyCoverRepository<T> : ProjectBaseRepository, IMyCoverRepository<T>
        where T : BaseViewModel
    {
        IMyCoverService<T> _Service;

        public MyCoverRepository(IMasterRepository masterRepository, IMyCoverService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public void Load(MyCoverViewModel model)
        {
            model.FirstName = _MasterRepo.DataSource.User.FirstName;
            model.UserImage = _MasterRepo.DataSource.User.UserPicture;
            model.LastName = _MasterRepo.DataSource.User.LastName;
        }
    }
}