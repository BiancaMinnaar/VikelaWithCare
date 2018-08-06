using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel
{
    public class ProfileModel : ProjectBaseViewModel
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private byte[] userImage;
        public byte[] UserImage
        {
            get { return userImage; }
            set
            {
                userImage = value;
                OnPropertyChanged("UserImage");
            }
        }

        private string idNumber;
        public string IDNumber
        {
            get { return idNumber; }
            set
            {
                idNumber = value;
                OnPropertyChanged("IDNumber");
            }
        }

        private string cellPhoneNumber;
        public string CellPhoneNumber
        {
            get { return cellPhoneNumber; }
            set
            {
                cellPhoneNumber = value;
                OnPropertyChanged("CellPhoneNumber");
            }
        }

        private string greeting;
        public string Greeting
        {
            get { return greeting; }
            set
            {
                greeting = value;
                OnPropertyChanged("Greeting");
            }
        }
    }
}
