using System;
using System.Web.Mvc;
using abw.ViewModels;

namespace abw.Controllers
{
	// todo: use Ninject
	public class CarsController : Controller
	{
		public ActionResult All(int? page)
		{
			Grid<CarForDisplay> cars = new Grid<CarForDisplay>();
			return View(cars);
		}

		public ActionResult New()
		{
			CarViewModel car = new CarViewModel();
			return View(car);
		}

		[HttpPost]
		public ActionResult New(CarViewModel car)
		{
			if (!ModelState.IsValid)
			{
				return View(car);
			}
			// todo
			return RedirectToAction("All");
		}

		public ActionResult Edit(long id)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public ActionResult Edit(CarViewModel car)
		{
			if (!ModelState.IsValid)
			{
				return View(car);
			}
			// todo
			return RedirectToAction("All");
		}

		public JsonResult Delete(long id)
		{
			throw new NotImplementedException();
		}
	}
}