using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Helpers;
using abw.ViewModels;

namespace abw.Controllers
{
	[Authorize]
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
			Car entity = car.ToEntity();
			Service.Create(entity);
			return RedirectToAction("Grid");
		}

		public ActionResult Edit(int id)
		{
			CarViewModel car = Service.GetCar(id);
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
	}
}