using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.ViewModels;

namespace abw.Controllers
{
	public class CarsController : BaseController<ICarService>
	{
		public CarsController(ICarService service)
			: base(service)
		{
		}

		public ActionResult All(int? page)
		{
			Grid<CarForDisplay> grid = Service.GetCarsGrid(page);
			return View(grid);
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
			Car entity = car.ToEntity();
			Service.Create(entity);
			return RedirectToAction("All");
		}

		public ActionResult Edit(int id)
		{
			CarViewModel car = Service.GetEditCar(id);
			return View(car);
		}

		[HttpPost]
		public ActionResult Edit(CarViewModel car)
		{
			if (!ModelState.IsValid)
			{
				return View(car);
			}
			Car entity = car.ToEntity();
			Service.Update(entity);
			return RedirectToAction("All");
		}

		public JsonResult Delete(int id)
		{
			bool success = Service.Delete(id);
			if (!success)
			{
				return Json(new
				{
					success = false,
					errorMessage = "Car has not been found"
				});
			}
			return Json(new { success = true }, JsonRequestBehavior.AllowGet);
		}
	}
}