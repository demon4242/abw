using System;
using System.Linq;
using System.Xml.Linq;
using abw.Common;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.DAL.Repositories
{
	public class CarsRepository : Repository<Car>, ICarsRepository
	{
		protected override string FileName => WebConfigManager.CarsFileName;

		public Car Get(string make, string model, int yearFrom, int? yearTo)
		{
			Car car = GetAll().SingleOrDefault(m => m.Make.ToLower() == make.ToLower()
				&& m.Model.ToLower() == model.ToLower()
				&& m.YearFrom == yearFrom
				&& m.YearTo == yearTo);
			return car;
		}

		// todo: place in generic repository
		public void Delete(Car car)
		{
			XDocument xDocument = XDocument.Load(FilePath);
			XElement carXml = xDocument.Elements(PluralEntityNameForXml).Elements(EntityNameForXml).SingleOrDefault(m =>
				m.Element(nameof(car.Make).LowerFirstLetter())?.Value.ToLower() == car.Make.ToLower()
				&& m.Element(nameof(car.Model).LowerFirstLetter())?.Value.ToLower() == car.Model.ToLower()
				&& m.Element(nameof(car.YearFrom).LowerFirstLetter())?.Value == car.YearFrom.ToString()
				&& m.Element(nameof(car.YearTo).LowerFirstLetter())?.Value == car.YearTo.ToString()
			);

			carXml?.Remove();
			xDocument.Save(FilePath);
		}

		public override void Update(Car car, Car originalCar)
		{
			string make = nameof(car.Make).LowerFirstLetter();
			string model = nameof(car.Model).LowerFirstLetter();
			string yearFrom = nameof(car.YearFrom).LowerFirstLetter();
			string yearTo = nameof(car.YearTo).LowerFirstLetter();

			XDocument xDocument = XDocument.Load(FilePath);
			XElement carXml = xDocument.Elements(PluralEntityNameForXml).Elements(EntityNameForXml).SingleOrDefault(m =>
				m.Element(make)?.Value.ToLower() == originalCar.Make.ToLower()
				&& m.Element(model)?.Value.ToLower() == originalCar.Model.ToLower()
				&& m.Element(yearFrom)?.Value == originalCar.YearFrom.ToString()
				&& m.Element(yearTo)?.Value == originalCar.YearTo.ToString()
			);

			if (carXml == null)
			{
				throw new NullReferenceException();
			}

			// todo: check if null
			carXml.Element(make).Value = car.Make;
			carXml.Element(model).Value = car.Model;
			carXml.Element(yearFrom).Value = car.YearFrom.ToString();
			carXml.Element(yearTo).Value = car.YearTo.ToString();

			xDocument.Save(FilePath);
		}
	}
}
