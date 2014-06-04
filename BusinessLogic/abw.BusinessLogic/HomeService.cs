using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.BusinessLogic
{
	public class HomeService : BaseService, IHomeService
	{
		public HomeService(IUnitOfWork uow)
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
