using SQLite;

namespace Vikela.Trunk.ViewModel.Offline
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public byte[] UserPicture { get; set; }
    }
}
