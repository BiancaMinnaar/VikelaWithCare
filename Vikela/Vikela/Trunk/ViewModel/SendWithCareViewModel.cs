using System;
using System.Collections.Generic;
using System.ComponentModel;
using Vikela.Root.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class SendWithCareViewModel : ProjectBaseViewModel
    {
        private List<PurchaseDetailsViewModel> _purchaseHistory;

        public new event PropertyChangedEventHandler PropertyChanged;
        public List<PurchaseDetailsViewModel> PurchaseHistory { get => _purchaseHistory; set { _purchaseHistory = value; OnPropertyChanged("EndDate"); } }
    }
}