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