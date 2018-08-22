using System;
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FistName"));
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

        private string tokenID;
        public string TokenID
        {
            get { return tokenID; }
            set
            {
                tokenID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TokenID"));
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
    }
}