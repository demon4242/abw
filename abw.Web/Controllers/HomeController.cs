using System.Collections.Generic;
using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.ViewModels;
using abw.Web.Utilities;
using abw.Web.Utilities.Helpers;

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

		[Route("carsTree")]
		public JsonNetResult CarsTree()
		{
			List<CarTreeItem> carsTree = Service.GetCarsTree();
			return new JsonNetResult(carsTree);
		}

		[Route("cars")]
		public ActionResult Cars()
		{
			List<CarForFullDisplay> cars = Service.GetCarsForFullDisplay();
			return View(cars);
		}

		[Route("cars/{make}")]
		public ActionResult CarsByMake(string make)
		{
			List<CarForFullDisplay> cars = Service.GetCarsForFullDisplay(make);
			return View("Cars", cars);
		}

		[Route("cars/{make}/{model}")]
		public ActionResult CarsByMakeAndModel(string make, string model)
		{
			List<CarForFullDisplay> cars = Service.GetCarsForFullDisplay(make, model);
			return View("Cars", cars);
		}

		[Route("cars/{make}/{model}/{yearFrom:int}/{yearTo:int?}")]
		public ActionResult Car(string make, string model, int yearFrom, int? yearTo)
		{
			CarForDisplay car = Service.GetCarForDisplay(make, model, yearFrom, yearTo);
			if (car == null)
			{
				return RedirectToAction("PageNotFound", "Errors");
			}
			return View("Car", car);
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
