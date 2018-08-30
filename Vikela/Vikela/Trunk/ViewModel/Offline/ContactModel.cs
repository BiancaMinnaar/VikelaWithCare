using SQLite;

namespace Vikela.Trunk.ViewModel.Offline
{
    public class ContactModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
		public string FirstName{ get; set; }
		public string LastName{ get; set; }
		public string CellNumber{ get; set; }
		public string IDNumber{ get; set; }
    }
}
