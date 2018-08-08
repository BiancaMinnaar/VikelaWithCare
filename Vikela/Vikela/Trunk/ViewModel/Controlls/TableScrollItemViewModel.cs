using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Newtonsoft.Json;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel;
using Vikela.Trunk.ViewModel.Controlls;

namespace Vikela.Implementation.ViewModel
{
    public class TableScrollItemViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public ProfileModel Profile { get; set; }
        public ICommand ItemClickedCommand { get; set; }
    }

    public class SmallTableMenuItemViewModelList : ProjectBaseViewModel, IEnumerable<TableScrollItemViewModel>
    {
        List<TableScrollItemViewModel> _List;

        public SmallTableMenuItemViewModelList()
        {
            _List = new List<TableScrollItemViewModel>();
        }

        public IEnumerator<TableScrollItemViewModel> GetEnumerator()
        {
            return _List.GetEnumerator();
        }

        IEnumerator<TableScrollItemViewModel> IEnumerable<TableScrollItemViewModel>.GetEnumerator()
        {
            return _List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}