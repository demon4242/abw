using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.BusinessLogic
{
	public class MyCarService : CrudService<MyCar>, IMyCarService
	{
		public MyCarService(IUnitOfWork uow)
			: base(uow)
		{
		}

		protected override IRepository<MyCar> Repository
		{
			get
			{
				return Uow.MyCars;
			}
		}

		new public int Create(MyCar myCar)
		{
			base.Create(myCar);
			return myCar.Id;
		}

		public List<CarMake> GetAllCarMakes()
		{
			List<CarMake> carMakes = Uow.CarMakes.All.ToList();
			return carMakes;
		}

		public List<Car> GetCarModelsByMake(int makeId)
		{
			List<Car> carModels = Uow.CarMakes.All.Single(m => m.Id == makeId).Cars.ToList();
			return carModels;
		}
	}
}
