using System.Collections.Generic;
using System.Windows.Input;
using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel.Controlls
{
    public class TrustedSourcesViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public IEnumerable<ProfileModel> ThreeSources = 
            new List<ProfileModel>{
                new ProfileModel(),
                new ProfileModel(),
                new ProfileModel()};
    }
}
