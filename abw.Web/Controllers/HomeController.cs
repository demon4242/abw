using System.Collections.Generic;
using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.ViewModels;

namespace abw.Controllers
{
	public class HomeController : BaseController<ICarService>
	{
		public HomeController(ICarService service)
			: base(service)
		{
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Cars()
		{
			List<CarForDisplay> cars = Service.GetCarsForDisplay();
			return View(cars);
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contacts()
		{
			return View();
		}
	}
}
