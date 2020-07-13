using LiveChartsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveChartsDemo.Database
{
	public static class DatabaseOperations
	{
		public static int CountCompanyRows()
		{
			int count;

			using (var db = new DataContext())
			{
				count = db.Company1.Count();
			}

			return count;
		}

		public static int CountImportRows()
		{
			int count;

			using (var db = new DataContext())
			{
				count = db.ShrimpImport.Count();
			}

			return count;
		}

		// Adds some preset values to the database - demo purpose only
		// Only called once
		public static void PopulateDatabase()
		{
			using (var db = new DataContext())
			{
				// 'i' will be the year
				for (int i = 2005; i < 2020; i++)
				{
					double value;

					if (i < 2010)
					{
						value = i * 1.5d;
					}
					else if (i == 2011)
					{
						value = i * 0.9d;
					}
					else if (i == 2012)
					{
						value = i * 0.5d;
					}
					else
					{
						value = i * 1.1d;
					}

					db.Company1.Add(new Data()
					{
						Year = i,
						Value = value,
						Comment = value >= i ? $"The company's value was rising in the year {i}" : $"The company's value was dropping in the year {i}"
					});
				}

				for (int i = 2015; i < 2020; i++)
				{
					db.ShrimpImport.Add(new Import()
					{
						Year = i,
						Country = "Poland",
						Tonnes = 50 + (2019 - i)
					});

					db.ShrimpImport.Add(new Import()
					{
						Year = i,
						Country = "Russia",
						Tonnes = 140 + i % 12
					});

					db.ShrimpImport.Add(new Import()
					{
						Year = i,
						Country = "Greece",
						Tonnes = 10 + i % 3
					});
				}

				db.SaveChanges();
			}
		}

		public static void ClearDatabase()
		{
			using (var db = new DataContext())
			{
				db.Company1.RemoveRange(db.Company1);
				db.ShrimpImport.RemoveRange(db.ShrimpImport);
				db.SaveChanges();
			}
		}

		public static List<Data> GetCompanyData()
		{
			List<Data> list;

			using (var db = new DataContext())
			{
				list = db.Company1.ToList<Data>();
			}

			return list is null ? new List<Data>() : list;

		}

		public static List<Import> GetImportData()
		{
			List<Import> list;

			using (var db = new DataContext())
			{
				list = db.ShrimpImport.ToList<Import>();
			}

			return list is null ? new List<Import>() : list;
		}

		// Generate some data on the run, without saving it to the database
		public static List<Data> GenerateCompanyData()
		{
			var list = new List<Data>();
			Random rng = new Random();

			// 'i' will be the year
			for (int i = 2005; i < 2020; i++)
			{
				double multiplier = rng.NextDouble();

				var data = new Data()
				{
					Year = i,
					Value = i * multiplier,
				};

				list.Add(data);
			}

			return list;
		}
	}
}
