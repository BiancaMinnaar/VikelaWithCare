using SQLite;
using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel.Offline
{
    public class UserModel : ProjectBaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FacebookToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public byte[] UserPicture { get; set; }
    }
}
