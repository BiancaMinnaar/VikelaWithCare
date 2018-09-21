using System.ComponentModel;
using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class RegisterViewModel : ProjectBaseViewModel
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        string firstName;
        public string FirstName 
        {
            get { return firstName; }
            set 
            {
                firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
            }
        }

        string idNumber;
        public string IDNumber
        {
            get { return idNumber; }
            set
            {
                idNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IDNumber"));
            }
        }

        string mobileNumber;
        public string MobileNumber
        {
            get { return mobileNumber; }
            set
            {
                mobileNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MobileNumber"));
            }
        }

        string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EmailAddress"));
            }
        }

        string userPictureURL;
        public string UserPictureURL
        {
            get { return userPictureURL; }
            set
            {
                userPictureURL = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserPictureURL"));
            }
        }

        byte[] userPicture;
        public byte[] UserPicture
        {
            get { return userPicture; }
            set
            {
                userPicture = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserPicture"));
            }
        }

        private string userID;
        public string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                OnPropertyChanged("UserID");
            }
        }

        private string oID;
        public string OID
        {
            get { return oID; }
            set
            {
                oID = value;
                OnPropertyChanged("OID");
            }
        }

        private string pictureStorageSASToken;
        public string PictureStorageSASToken
        {
            get { return pictureStorageSASToken; }
            set
            {
                pictureStorageSASToken = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PictureStorageSASToken"));
            }
        }

        public RegisterViewModel()
        {
            ValidationRules.Add(GetRule(() =>
            {
				return FirstName != null && FirstName.Length > 0;
            }, "FirstName is empty."));
            //ValidationRules.Add(GetRule(() =>
            //{
            //    return EmailAddress != null && EmailAddress.Length > 0;
            //}, "EmailAddress is empty."));
            ValidationRules.Add(GetRule(() =>
            {
                return IDNumber != null && IDNumber.Length > 0;
            }, "IDNumber is empty."));
            ValidationRules.Add(GetRule(() =>
            {
                return LastName != null && LastName.Length > 0;
            }, "LastName is empty."));
            ValidationRules.Add(GetRule(() =>
            {
                return MobileNumber != null && MobileNumber.Length > 0;
            }, "MobileNumber is empty."));
            
        }
    }
}