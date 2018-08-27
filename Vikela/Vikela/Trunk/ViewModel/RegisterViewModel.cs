using System;
using System.ComponentModel;
using Newtonsoft.Json;
using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class RegisterViewModel : ProjectBaseViewModel
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        private Guid uniqueIdentifier;
        [JsonProperty("userId")]
        public Guid UniqueIdentifier
        {
            get { return uniqueIdentifier; }
            set
            {
                uniqueIdentifier = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UniqueIdentifier"));
            }
        }
        string firstName;
        [JsonProperty("firstName")]
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
        [JsonProperty("lastName")]
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
        [JsonProperty("idNumber")]
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
        [JsonProperty("mobileNumber")]
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
        [JsonProperty("eMail")]
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
        [JsonProperty("profileImageUrl")]
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
        [JsonIgnore]
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
        [JsonIgnore]
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
        [JsonIgnore]
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
        [JsonIgnore]
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