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
            get
            {
                if (ThreeSources != null && ThreeSources.Count > 0)
                    return ThreeSources[0].UserImage.Selfie;
                return null;
            }
            set { ThreeSources[0].UserImage.Selfie = value; OnPropertyChanged("SourceOnePicture"); }
        }
        public byte[] SourceTwoPicture
        {
            get
            {
                if (ThreeSources != null && ThreeSources.Count > 1)
                    return ThreeSources[1].UserImage.Selfie;
                return null;
            }
            set { ThreeSources[1].UserImage.Selfie = value; OnPropertyChanged("SourceTwoPicture"); }
        }
        public byte[] SourceThreePicture
        {
            get 
            {
                if (ThreeSources != null && ThreeSources.Count > 2)
                    return ThreeSources[2].UserImage.Selfie;
                return null;
            }
            set { ThreeSources[2].UserImage.Selfie = value; OnPropertyChanged("SourceThreePicture"); }
        }

        public List<ProfileModel> ThreeSources = 
            new List<ProfileModel>{
                new ProfileModel(),
                new ProfileModel(),
                new ProfileModel()};
    }
}
