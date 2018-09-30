using System.Collections.Generic;
using System.Windows.Input;
using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel.Controlls
{
    public class CareVoucherViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public string VoucherName { get; set; }
        public List<byte[]> Images { get; set; }
        public string DisplayAmount { get; set; }
    }
}
