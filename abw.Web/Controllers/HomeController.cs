using System.Collections.Generic;
using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.ViewModels;

namespace abw.Controllers
{
	public class HomeController : BaseController<ICarsService>
	{
		public HomeController(ICarsService service)
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

		// todo: rename after 'Routing' libraty is used
		// todo: use another view
		public ActionResult CarsByMake(string make)
		{
			List<CarForDisplay> cars = Service.GetCarsForDisplay(make);
			return View("Cars", cars);
		}

		public ActionResult Car(int id)
		{
			CarForDisplay carForDisplay = Service.GetCarForDisplay(id);
			return View(carForDisplay);
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
