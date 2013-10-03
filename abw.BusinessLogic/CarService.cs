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

		protected override IRepository<Car> Repository
		{
			get
			{
				IRepository<Car> repository = Uow.Cars;
				return repository;
			}
		}
	}
}
