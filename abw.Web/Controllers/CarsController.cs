using System.Collections.Generic;
using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Helpers;
using abw.ViewModels;

namespace abw.Controllers
{
	public class CarsController : BaseController<ICarService>
	{
		public CarsController(ICarService service)
			: base(service)
		{
		}

		public ActionResult Grid()
		{
			Grid<CarForDisplay> grid = Service.GetCarsGrid();
			return View(grid);
		}

		public JsonNetResult All(int page)
		{
			Grid<CarForDisplay> grid = Service.GetCarsGrid(page);
			return new JsonNetResult(grid);
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
			CarMake entity = car.ToEntity();
			Service.Create(entity);
			return RedirectToAction("Grid");
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
			CarMake entity = car.ToEntity();
			Service.Update(entity);
			return RedirectToAction("Grid");
		}

		[HttpPost]
		public JsonResult Delete(int id)
		{
			bool success = Service.Delete(id);
			if (!success)
			{
				return Json(new
				{
					success = false,
					errorMessage = "Машина не найдена"
				});
			}
			return Json(new { success = true });
		}

		/// <summary>
		/// Ensures that make of the car is unique
		/// </summary>
		public JsonResult CarMakeIsUnique(string make, int id)
		{
			bool isUnique = Service.CarMakeIsUnique(make, id);
			return Json(isUnique, JsonRequestBehavior.AllowGet);
		}
	}
}