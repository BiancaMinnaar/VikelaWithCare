using System.Windows.Input;
using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel.Controlls
{
    public class SiyabongaViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public string TotalBenefits { get; set; }
        public string ClaimFreePeriod { get; set; }
    }
}
