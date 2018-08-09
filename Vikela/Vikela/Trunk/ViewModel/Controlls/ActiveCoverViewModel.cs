using System.Windows.Input;
using Vikela.Root.ViewModel;
using Xamarin.Forms;

namespace Vikela.Trunk.ViewModel.Controlls
{
    public class ActiveCoverViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public Color TileColor { get; set; }
        public string CareAmount { get; set; }
        public byte[] BeneficiaryImage { get; set; }
    }
}
