using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Service
{
    public interface ICareVoucehersService<T>
    {
        Task<T> YourMethodNameAsync(CareVoucehersViewModel model);
    }
}
