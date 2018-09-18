using System;
using Vikela.Implementation.ViewController;
using Vikela.Implementation.ViewModel;
using Vikela.Root.View;
using Xamarin.Forms;
using C1.Xamarin.Forms.Gauge;

namespace Vikela.Implementation.View
{
    public partial class MonthRadialGraphView : ProjectBaseContentView<MonthRadialGraphViewController, MonthRadialGraphViewModel>
    {
        public MonthRadialGraphView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
			graph = GetRadialGauge();
        }

        protected override void SetSVGCollection()
        {
        }
		public static C1RadialGauge GetRadialGauge()
		{
			//Instantiate RadialGauge and set its properties
			C1RadialGauge gauge = new C1RadialGauge();
			gauge.Value = 35;
			gauge.Min = 0;
			gauge.Max = 100;
			gauge.StartAngle = -20;
			gauge.SweepAngle = 220;
			gauge.AutoScale = true;
			gauge.ShowText = GaugeShowText.None;
			gauge.PointerColor = Xamarin.Forms.Color.Blue;
			gauge.ShowRanges = true;
			
			//Create Ranges
			GaugeRange low = new GaugeRange();
			GaugeRange med = new GaugeRange();
			GaugeRange high = new GaugeRange();
			
			//Customize Ranges
			low.Color = Xamarin.Forms.Color.Red;
			low.Min = 0;
			low.Max = 40;
			med.Color = Xamarin.Forms.Color.Yellow;
			med.Min = 40;
			med.Max = 80;
			high.Color = Xamarin.Forms.Color.Green;
			high.Min = 80;
			high.Max = 100;
			
			//Add Ranges to RadialGauge
			gauge.Ranges.Add(low);
			gauge.Ranges.Add(med);
			gauge.Ranges.Add(high);
			
			return gauge;
		}
    }
}


