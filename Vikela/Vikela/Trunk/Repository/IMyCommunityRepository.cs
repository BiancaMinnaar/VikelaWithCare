using Vikela.Implementation.ViewModel;

namespace Vikela.Interface.Repository
{
    public interface IMyCommunityRepository
    {
        MyCommunityViewModel GetCommunityFromMaster();
    }
}
