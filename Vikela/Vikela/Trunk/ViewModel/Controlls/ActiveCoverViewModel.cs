using System;
using System.Windows.Input;
using Vikela.Root.ViewModel;

namespace Vikela.Trunk.ViewModel.Controlls
{
    public class ActiveCoverViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ICommand ItemClickedCommand { get; set; }
    }
}
