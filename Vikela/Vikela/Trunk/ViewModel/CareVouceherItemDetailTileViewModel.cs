using System.Windows.Input;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Implementation.ViewModel
{
    public class CareVouceherItemDetailTileViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public string AmountText { get; set; }
        public byte[] Selfie { get; set; }
    }
}