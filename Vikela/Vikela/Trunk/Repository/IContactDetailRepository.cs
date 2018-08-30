using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IContactDetailRepository
    {
        void Load(ContactDetailViewModel model);
    }
}
