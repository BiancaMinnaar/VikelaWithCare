using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class ContactDetailViewModel : ProjectBaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _cellNumber;
        private string _iDNumber;
        private byte[] _contactPicture;
        private string _pictureURL;

        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged("FirstName"); } }
        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged("LastName"); } }
        public string CellNumber { get => _cellNumber; set { _cellNumber = value; OnPropertyChanged("CellNumber"); } }
        public string IDNumber { get => _iDNumber; set { _iDNumber = value; OnPropertyChanged("IDNumber"); } }
        public byte[] ContactPicture { get => _contactPicture; set { _contactPicture = value; OnPropertyChanged("ContactPicture"); } }
        public string PictureURL { get => _pictureURL; set { _pictureURL = value; OnPropertyChanged("PictureURL"); }  }
    }
}