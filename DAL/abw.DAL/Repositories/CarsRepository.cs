using System.Linq;
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
	}
}
