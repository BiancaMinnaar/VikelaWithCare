using System;
using System.Globalization;
using System.Windows.Input;
using Vikela.Implementation.ViewModel;
using Vikela.Root.ViewModel;
using Xamarin.Forms;

namespace Vikela.Trunk.ViewModel.Controlls
{
    public class PurchaseHistoryDetailViewModel : ProjectBaseViewModel, ITableScrollItemModel
    {
        public int Index { get; set; }
        public PurchaseDetailsViewModel HistoryDetails { get; set; }
        public ICommand ItemClickedCommand { get; set; }
        public Color TileColor { get => GetRobotColor(HistoryDetails.StartDate, HistoryDetails.EndDate); }
        public string CoverMoneyDisplay { get => HistoryDetails.Cover.ToString("C", new CultureInfo("en-ZA")); }
        public string DaysDisplay {
            get
            {
                var timeCalc = TimeSpan.FromTicks(HistoryDetails.EndDate.AddTicks(-HistoryDetails.StartDate.Ticks).Ticks).Days;

                return $"{timeCalc} days";
            }
        }
        public string StartDate { get => HistoryDetails.StartDate.ToString("yyyy-MM-dd", new CultureInfo("en-ZA")); }
        public string EndDate { get => HistoryDetails.EndDate.ToString("yyyy-MM-dd", new CultureInfo("en-ZA")); }

        Color GetRobotColor(DateTime startTime, DateTime endTime)
        {
            var monthsDifference = Math.Abs((startTime.Month - endTime.Month) + 12 * (startTime.Year - endTime.Year));
            if (monthsDifference == 0)
                return Color.Red;
            if (monthsDifference == 1)
                return Color.Orange;
            return Color.FromHex("#BBDE6B");
        }
    }
}
