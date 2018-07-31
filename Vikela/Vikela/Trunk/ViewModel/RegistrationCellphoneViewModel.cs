using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class RegistrationCellphoneViewModel : ProjectBaseViewModel
    {
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
    }
}