using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class SelfieViewModel : ProjectBaseViewModel
    {
        private byte[] selfie;
        public byte[] Selfie
        {
            get { return selfie; }
            set 
            {
                selfie = value;
                OnPropertyChanged("Selfie");
            }
        }
    }
}