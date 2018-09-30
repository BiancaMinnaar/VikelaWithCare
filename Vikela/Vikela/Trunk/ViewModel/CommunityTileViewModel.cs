using System;
using System.Windows.Input;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Implementation.ViewModel
{
    public class CommunityTileViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public string TotalCover { get; set; }
        public string Name { get; set; }
    }
}