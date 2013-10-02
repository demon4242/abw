using System.Web.Mvc;
using abw.DAL.Repositories;

namespace abw.Controllers
{
	public abstract class BaseController : Controller
	{
		protected UnitOfWork Uow = new UnitOfWork();

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			Uow.Dispose();
		}
	}
}