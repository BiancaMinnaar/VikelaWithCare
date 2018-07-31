using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class MyCoverViewModel : ProjectBaseViewModel
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
            set{
                userImage = value;
                OnPropertyChanged("UserName");
            }
        }
    }
}