using System.ComponentModel;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Offline;

namespace Vikela.Implementation.ViewModel
{
    public class AddContactViewModel : ProjectBaseViewModel
    {
        private ContactDetailViewModel _sourceDetail;

        public new event PropertyChangedEventHandler PropertyChanged;
        public ContactDetailViewModel SourceDetail { get => _sourceDetail; set { _sourceDetail = value; OnPropertyChanged("SourceDetail"); } }
    }
}