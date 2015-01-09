using System.Web.Mvc;

namespace abw.Controllers
{
	// todo: prevent actions from direct access
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