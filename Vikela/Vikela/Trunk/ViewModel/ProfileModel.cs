﻿using System.Collections.Generic;
using Vikela.Implementation.ViewModel;
using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel
{
    public class ProfileModel : ProjectBaseViewModel
    {
        private string firstName;
        internal string userID;
        public string UserID 
        {
            get { return userID; }
            set
            {
                userID = value;
                OnPropertyChanged("UserID");
            }
        }

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

        internal SelfieViewModel userImage;
        public SelfieViewModel UserImage { get => userImage; set { userImage = value; OnPropertyChanged("UserImage"); } }

        byte[] barCode;
        public byte[] BarCode 
        {
            get { return barCode; }
            set 
            { 
                barCode = value; 
                OnPropertyChanged("BarCode"); 
            } 
        }

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

        private string greeting;
        private List<ContactDetailViewModel> _trustedSources;

        public string Greeting
        {
            get { return greeting; }
            set
            {
                greeting = value;
                OnPropertyChanged("Greeting");
            }
        }

        public List<ContactDetailViewModel> TrustedSources { get => _trustedSources; set { _trustedSources = value; OnPropertyChanged("TrustedSources"); } }

    }
}
