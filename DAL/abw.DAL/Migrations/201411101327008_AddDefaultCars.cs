using System.Collections.Generic;

namespace abw.DAL.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddDefaultCars : DbMigration
	{
		private readonly List<string> _cars = new List<string>
		{
			"Nissan X-Trail 2001 2007",
			"Seat Altea 2004",
			"Seat Arosa 1997 2000",
			"Seat Arosa 2000 2004",
			"Seat Cordoba 1993 1999",
			"Seat Cordoba 1999 2002",
			"Seat Ibiza 1993 1999",
			"Seat Ibiza 1999 2002",
			"Seat Ibiza 2002 2008",
			"Seat Inca 1996 2003",
			"Seat Toledo 1998 2005",
			"Skoda Fabia 1999 2007",
			"Skoda Felicia 1994 2001",
			"Skoda Octavia 1996 2004",
			"Skoda Superb 2001 2008",
			"Toyota RAV4 2000 2005",
			"Volkswagen Caddy 1995 2003",
			"Volkswagen Lupo 1998 2005",
			"Volkswagen Polo 1994 2002",
			"Volkswagen Polo 2002 2006",
			"Volkswagen Polo 2006 2009"
		};

		public override void Up()
		{
			foreach (string carString in _cars)
			{
				const int yearToIndex = 3;
				const string nullValue = "null";

				string[] parts = carString.Split(' ');

				string make = parts[0];
				string model = parts[1];
				int yearFrom = int.Parse(parts[2]);
				string yearTo = yearToIndex < parts.Length
					? int.Parse(parts[yearToIndex]).ToString()
					: nullValue;

				string sql = string.Format("INSERT INTO Cars (Make, Model, YearFrom, YearTo) VALUES ('{0}', '{1}', {2}, {3})", make, model, yearFrom, yearTo);
				Sql(sql);
			}
		}

		public override void Down()
		{
			Sql("DELETE FROM Cars");
		}
	}
}
