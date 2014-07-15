using System.Collections.Generic;
using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Helpers;
using abw.ViewModels;

namespace abw.Controllers
{
	[Authorize]
	public class MyCarsController : BaseController<IMyCarService>
	{
		public MyCarsController(IMyCarService service)
			: base(service)
		{
		}

		public ActionResult Grid()
		{
			Grid<MyCarForDisplay> grid = Service.GetMyCarsGrid();
			return View(grid);
		}

		public JsonNetResult All(int page)
		{
			Grid<MyCarForDisplay> grid = Service.GetMyCarsGrid(page);
			return new JsonNetResult(grid);
		}

		public ActionResult New()
		{
			MyCarViewModel myCar = Service.GetNewCar();
			return View(myCar);
		}

		[HttpPost]
		public ActionResult New(MyCarViewModel myCar)
		{
			if (!ModelState.IsValid)
			{
				return View(myCar);
			}
			MyCar entity = myCar.ToEntity();
			int myCarId = Service.Create(entity);
			FileManager.SaveMyCarPhoto(myCar.Photo, myCarId, Server);
			return RedirectToAction("Grid");
		}

		public ActionResult Edit(int id)
		{
			MyCarViewModel car = Service.GetEditCar(id);
			return View(car);
		}

		[HttpPost]
		public ActionResult Edit(MyCarViewModel myCar)
		{
			if (!ModelState.IsValid)
			{
				return View(myCar);
			}
			MyCar entity = myCar.ToEntity();
			Service.Update(entity);
			return RedirectToAction("Grid");
		}

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

		public JsonNetResult GetCarModelsByMake(int makeId)
		{
			List<SelectListItem> carModels = Service.GetCarModelsSelectListByMake(makeId);
			return new JsonNetResult(carModels);
		}
	}
}