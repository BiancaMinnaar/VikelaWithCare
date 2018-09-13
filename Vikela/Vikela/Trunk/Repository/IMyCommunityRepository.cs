using System.Threading.Tasks;
using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IMyCommunityRepository
    {
        MyCommunityViewModel GetCommunityFromMaster();
        Task SaveCommunityAsync(MyCommunityViewModel model);
        Task UpdateMasterWithCommunityAsync(MyCommunityViewModel model);
    }
}
