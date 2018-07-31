using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class RegistrationNameViewModel : ProjectBaseViewModel
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
    }
}