using System.Windows.Input;
using Newtonsoft.Json;

namespace Vikela.Trunk.ViewModel.Controlls
{
    public interface ITableScrollItemModel
    {
        [JsonIgnore]
        int Index { get; set; }
        [JsonIgnore]
        ICommand ItemClickedCommand { get; set; }
    }
}
