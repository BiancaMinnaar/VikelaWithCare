using System;
using System.ComponentModel;
using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class PurchaseDetailsViewModel : ProjectBaseViewModel
    {
        private string _purchasedAt;
        private string _product;
        private double _cover;
        private double _premium;
        private DateTime _startDate;
        private DateTime _endDate;
        private Guid _beneficiaryID;

        public new event PropertyChangedEventHandler PropertyChanged;
        public string PurchasedAt { get => _purchasedAt; set { _purchasedAt = value; OnPropertyChanged("PurchasedAt"); } }
        public string Product { get => _product; set { _product = value; OnPropertyChanged("Product"); } }
        public double Cover { get => _cover; set { _cover = value; OnPropertyChanged("Cover"); } }
        public double Premium { get => _premium; set { _premium = value; OnPropertyChanged("Premium"); } }
        public DateTime StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged("StartDate"); } }
        public DateTime EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged("EndDate"); } }
        public Guid BeneficiaryID { get => _beneficiaryID; set { _beneficiaryID = value; OnPropertyChanged("EndDate"); } }
    }
}