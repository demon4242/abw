using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.DAL.Repositories;

namespace abw.BusinessLogic
{
	public class HomeService : BaseService, IHomeService
	{
		public HomeService(UnitOfWork uow)
			: base(uow)
		{
		}

		public List<MyCar> GetMyCars()
		{
			List<MyCar> myCars = Uow.MyCars.All.ToList();
			return myCars;
		}
	}
}
