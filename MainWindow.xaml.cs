using LiveChartsDemo.Database;
using System.Windows;

namespace LiveChartsDemo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			// Populate the database first
			DatabaseOperations.ClearDatabase();
			DatabaseOperations.PopulateDatabase();

			//var graph = new ExampleLineGraph();

			//MainGrid.Children.Add(graph);

			var graph2 = new ExampleColumnGraph();
			MainGrid.Children.Add(graph2);
		}


	}
}
