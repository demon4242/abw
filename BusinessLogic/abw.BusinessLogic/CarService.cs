using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.BusinessLogic
{
	public class CarService : CrudService<CarMake>, ICarService
	{
		public CarService(IUnitOfWork uow)
			: base(uow)
		{
		}

		public bool CarMakeIsUnique(string make, int id)
		{
			bool isUnique = Repository.All.SingleOrDefault(m => m.Id != id
				&& m.Name.Trim().ToLower() == make.Trim().ToLower()) == null;
			return isUnique;
		}

		protected override IRepository<CarMake> Repository
		{
			get
			{
				return Uow.CarMakes;
			}
		}
	}
}
