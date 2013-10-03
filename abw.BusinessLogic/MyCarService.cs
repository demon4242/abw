using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;
using abw.DAL.Repositories;

namespace abw.BusinessLogic
{
	public class MyCarService : CrudService<MyCar>, IMyCarService
	{
		public MyCarService(UnitOfWork uow)
			: base(uow)
		{
		}

		protected override IRepository<MyCar> Repository
		{
			get
			{
				IRepository<MyCar> repository = Uow.MyCars;
				return repository;
			}
		}
	}
}
