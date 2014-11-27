using System.Collections.Generic;
using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.ViewModels;
using abw.Web.Utilities;

namespace abw.Controllers
{
	public class HomeController : BaseController<ICarsService>
	{
		public HomeController(ICarsService service)
			: base(service)
		{
		}

		[Route("")]
		public ActionResult Index()
		{
			return View();
		}

		[Route("cars")]
		public ActionResult Cars()
		{
			List<CarForDisplay> cars = Service.GetCarsForDisplay();
			return View(cars);
		}

		[Route("cars/{make}")]
		public ActionResult CarsByMake(string make)
		{
			List<CarForDisplay> cars = Service.GetCarsForDisplay(make);
			return View("Cars", cars);
		}

		[Route("cars/{id:int}")]
		public ActionResult Car(int id)
		{
			CarForDisplay carForDisplay = Service.GetCarForDisplay(id);
			return View(carForDisplay);
		}

		[Route("about")]
		public ActionResult About()
		{
			return View();
		}

		[Route("contacts")]
		public ActionResult Contacts()
		{
			return View();
		}
	}
}
