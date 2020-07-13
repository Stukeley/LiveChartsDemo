using LiveCharts;
using LiveCharts.Wpf;
using LiveChartsDemo.Database;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace LiveChartsDemo
{
	public partial class ExampleLineGraph : UserControl
	{
		public SeriesCollection Series { get; set; }

		// We can preset the labels ourselves
		public string[] LabelsX { get; set; }

		// We'll can also use a formatter to do it for us
		public Func<double, string> YFormatter { get; set; }

		public ExampleLineGraph()
		{
			InitializeComponent();

			PopulateChart();
		}

		public void PopulateChart()
		{
			// List from the database
			var list1 = DatabaseOperations.GetCompanyData();
			var list2 = DatabaseOperations.GenerateCompanyData();

			// Columns (years) - every 4 years
			var year1 = from c in list1 select c.Year;

			// Values
			var value1 = (from c in list1 select c.Value).ToList();
			var value2 = (from c in list2 select c.Value).ToList();

			Series = new SeriesCollection
			{
				new LineSeries
				{
					Title="Company 1",
					Values= new ChartValues<double>(value1),
					Stroke=Brushes.Red,
					Fill=null
				},
				new LineSeries
				{
					Title="Company 2",
					Values=new ChartValues<double>(value2),
					Stroke=Brushes.Blue,
					Fill=null
				}
			};

			// Map all the years to array
			LabelsX = year1.Select(i => i.ToString()).ToArray();

			// Make a formatter that will convert double values to string
			YFormatter = value => value.ToString("C");

			DataContext = this;
		}
	}
}
