using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.BusinessLogic
{
	public class CarService : CrudService<Car>, ICarService
	{
		public CarService(IUnitOfWork uow)
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
	}
}
