using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;
using abw.DAL.Repositories;

namespace abw.BusinessLogic
{
	public class CarService : CrudService<Car>, ICarService
	{
		public CarService(UnitOfWork uow)
			: base(uow)
		{
		}

		public bool CarMakeIsUnique(string make, int id)
		{
			bool isUnique = Repository.All.SingleOrDefault(m => m.Id != id && m.Make.Trim().ToLower() == make.Trim().ToLower()) == null;
			return isUnique;
		}

		protected override IRepository<Car> Repository
		{
			get
			{
				return Uow.Cars;
			}
		}
	}
}
