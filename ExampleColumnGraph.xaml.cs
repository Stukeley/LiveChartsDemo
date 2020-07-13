using LiveCharts;
using LiveCharts.Wpf;
using LiveChartsDemo.Database;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace LiveChartsDemo
{

	public partial class ExampleColumnGraph : UserControl
	{
		public SeriesCollection Series { get; set; }

		// We can preset the labels ourselves
		public string[] LabelsX { get; set; }

		// We'll can also use a formatter to do it for us
		public Func<double, string> YFormatter { get; set; }

		public ExampleColumnGraph()
		{
			InitializeComponent();

			PopulateChart();
		}

		public void PopulateChart()
		{
			var list = DatabaseOperations.GetImportData();

			var years = (from c in list select c.Year).Distinct();

			var tonnesPL = (from c in list where c.Country == "Poland" select c.Tonnes).ToList();
			var tonnesRU = (from c in list where c.Country == "Russia" select c.Tonnes).ToList();
			var tonnesGR = (from c in list where c.Country == "Greece" select c.Tonnes).ToList();

			Series = new SeriesCollection
			{
				new ColumnSeries
				{
					Title="Poland",
					Values=new ChartValues<int>(tonnesPL),
					Fill=new SolidColorBrush(Color.FromRgb(255,0,0))
				},
				new ColumnSeries
				{
					Title="Russia",
					Values=new ChartValues<int>(tonnesRU),
					Fill=new SolidColorBrush(Color.FromRgb(255,0,255))
				},
				new ColumnSeries
				{
					Title="Greece",
					Values=new ChartValues<int>(tonnesGR),
					Fill=new SolidColorBrush(Color.FromRgb(0,0,255))
				}
			};

			LabelsX = years.Select(i => i.ToString()).ToArray();

			YFormatter = value => value.ToString() + "t";

			DataContext = this;
		}
	}
}
