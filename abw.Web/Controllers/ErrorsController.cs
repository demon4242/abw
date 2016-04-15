using System.Web.Mvc;

namespace abw.Controllers
{
	public class ErrorsController : Controller
	{
		public ActionResult GenericError()
		{
			return View();
		}

		public ActionResult PageNotFound()
		{
			return View();
		}

		public ActionResult InternalServerError()
		{
			return View();
		}
	}
}