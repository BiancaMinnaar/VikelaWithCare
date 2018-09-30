using System;
using System.Threading.Tasks;
using Vikela.Root.Repository;
using Vikela.Implementation.ViewModel;
using Vikela.Interface.Repository;
using Vikela.Interface.Service;

namespace Vikela.Implementation.Repository
{
    public class FriendDetailRepository<T> : ProjectBaseRepository, IFriendDetailRepository<T>
    {
        IFriendDetailService<T> _Service;

        public FriendDetailRepository(IMasterRepository masterRepository, IFriendDetailService<T> service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task AddFriendAsync(FriendDetailViewModel model)
        {
            await _Service.AddFriendAsync(model);
        }
    }
}