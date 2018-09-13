using SQLite;

namespace Vikela.Trunk.ViewModel.Offline
{
    public class CommunityModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CommunityName { get; set; }
    }
}
