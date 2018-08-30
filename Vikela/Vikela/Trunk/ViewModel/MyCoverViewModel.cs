using System.Collections.Generic;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Implementation.ViewModel
{
    public class MyCoverViewModel : ProjectBaseViewModel
    {
        private ProfileModel _userProfile;
        private List<ITableScrollItemModel> _detailTiles;

        public ProfileModel UserProfile { get => _userProfile; set { _userProfile = value; OnPropertyChanged("UserProfile"); } }
        public List<ITableScrollItemModel> DetailTiles { get => _detailTiles; set { _detailTiles = value; OnPropertyChanged("DetailTiles"); } }
    }
}