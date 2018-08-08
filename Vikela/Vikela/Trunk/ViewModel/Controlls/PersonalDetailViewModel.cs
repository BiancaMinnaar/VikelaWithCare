using System.Windows.Input;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Implementation.ViewModel
{
    public class PersonalDetailViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ProfileModel Profile { get; set; }
        public ICommand ItemClickedCommand { get; set; }
    }
}