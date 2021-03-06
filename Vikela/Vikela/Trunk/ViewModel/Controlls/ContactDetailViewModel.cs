using System.ComponentModel;
using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class ContactDetailViewModel : ProjectBaseViewModel, INotifyPropertyChanged
    {
		internal string _userID;
		internal string _firstName;
        internal string _lastName;
        internal string _email;
        internal string _cellNumber;
        internal string _iDNumber;
        internal SelfieViewModel _contactPicture;
        internal string _pictureURL;

        public new event PropertyChangedEventHandler PropertyChanged;
        public string UserID { get => _userID; set { _userID = value; OnPropertyChanged("UserID"); } }
        public string FirstName { get => _firstName; set { _firstName = value; OnPropertyChanged("FirstName"); } }
        public string LastName { get => _lastName; set { _lastName = value; OnPropertyChanged("LastName"); } }
        public string CellNumber { get => _cellNumber; set { _cellNumber = value; OnPropertyChanged("CellNumber"); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged("Email"); } }
        public string IDNumber { get => _iDNumber; set { _iDNumber = value; OnPropertyChanged("IDNumber"); } }
        public SelfieViewModel ContactPicture { get => _contactPicture; set { _contactPicture = value; OnPropertyChanged("ContactPicture"); } }
        public string PictureURL { get => _pictureURL; set { _pictureURL = value; OnPropertyChanged("PictureURL"); }  }
    }
}