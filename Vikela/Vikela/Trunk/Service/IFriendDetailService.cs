using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface IFriendDetailService<T>
    {
        Task<T> AddFriendAsync(FriendDetailViewModel model);
    }
}
