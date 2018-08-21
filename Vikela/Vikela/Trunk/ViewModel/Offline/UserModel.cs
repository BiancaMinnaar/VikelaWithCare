using SQLite;

namespace Vikela.Trunk.ViewModel.Offline
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FacebookToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string IDNumber { get; set; }
        public string EmailAddress { get; set; }
        public string OID { get; set; }
        public string TokenID { get; set; }
        public string PictureStorageSASToken { get; set; }
        public byte[] UserPicture { get; set; }
    }
}
