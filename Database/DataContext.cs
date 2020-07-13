using LiveChartsDemo.Models;
using System.Data.Entity;

namespace LiveChartsDemo.Database
{
	public class DataContext : DbContext
	{
		public DbSet<Data> Company1 { get; set; }

		public DbSet<Import> ShrimpImport { get; set; }

	}
}
