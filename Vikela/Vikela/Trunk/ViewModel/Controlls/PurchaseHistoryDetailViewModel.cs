using System.Drawing;
using System.Globalization;
using System.Windows.Input;
using Vikela.Implementation.ViewModel;
using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel.Controlls
{
    public class PurchaseHistoryDetailViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public PurchaseDetailsViewModel HistoryDetails { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public Color TileColor { get; set; }
        public string CoverMoneyDisplay { get => HistoryDetails.Cover.ToString("C", new CultureInfo("en-ZA")); }
    }
}
