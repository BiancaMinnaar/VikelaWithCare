using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class RegistrationIDNumberViewModel : ProjectBaseViewModel
    {
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

    }
}