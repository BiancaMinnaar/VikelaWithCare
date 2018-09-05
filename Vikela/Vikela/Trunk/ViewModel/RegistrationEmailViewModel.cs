using System;
using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class RegistrationEmailViewModel : ProjectBaseViewModel
    {
        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                OnPropertyChanged("EmailAddress");
            }
        }
    }
}