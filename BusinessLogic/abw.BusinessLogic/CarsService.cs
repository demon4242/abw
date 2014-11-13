using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.BusinessLogic
{
	public class CarsService : CrudService<Car>, ICarsService
	{
		public CarsService(IUnitOfWork uow)
			: base(uow)
		{
		}

		protected override IRepository<Car> Repository
		{
			get
			{
				return Uow.Cars;
			}
		}

		public List<Car> GetAll()
		{
			List<Car> cars = Uow.Cars.All.ToList();
			return cars;
		}

		public List<Car> GetByMake(string make)
		{
			List<Car> cars = Uow.Cars.All.Where(m => m.Make.ToLower() == make.ToLower()).ToList();
			return cars;
		}
	}
}
