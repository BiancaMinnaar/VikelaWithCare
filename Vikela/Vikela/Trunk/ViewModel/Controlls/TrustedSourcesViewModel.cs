using System.Collections.Generic;
using System.Windows.Input;
using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel.Controlls
{
    public class TrustedSourcesViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public byte[] SourceOnePicture
        {
            get => ThreeSources[0].UserImage;
            set { ThreeSources[0].UserImage = value; OnPropertyChanged("SourceOnePicture"); }
        }
        public byte[] SourceTwoPicture
        {
            get => ThreeSources[1].UserImage;
            set { ThreeSources[0].UserImage = value; OnPropertyChanged("SourceTwoPicture"); }
        }
        public byte[] SourceThreePicture
        {
            get => ThreeSources[2].UserImage;
            set { ThreeSources[0].UserImage = value; OnPropertyChanged("SourceThreePicture"); }
        }

        public List<ProfileModel> ThreeSources = 
            new List<ProfileModel>{
                new ProfileModel(),
                new ProfileModel(),
                new ProfileModel()};
    }
}
