using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Newtonsoft.Json;
using Vikela.Root.ViewModel;
using Vikela.Trunk.ViewModel;

namespace Vikela.Implementation.ViewModel
{
    public class TableScrollItemViewModel : ProjectBaseViewModel
    {
        [JsonIgnore]
        public int ListIndex { get; set; }
        public ProfileModel Profile { get; set; }
        [JsonIgnore]
        public ICommand MenuClickedCommand { get; set; }
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