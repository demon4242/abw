using System.Collections.Generic;
using abw.DAL.Entities;

namespace abw.BusinessLogic.Interfaces
{
	public interface IHomeService : IBaseService
	{
		List<MyCar> GetMyCars();
	}
}
