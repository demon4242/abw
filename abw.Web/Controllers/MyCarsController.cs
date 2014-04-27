﻿using System.Collections.Generic;
using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.ViewModels;

namespace abw.Controllers
{
	public class MyCarsController : BaseController<IMyCarService>
	{
		public MyCarsController(IMyCarService service)
			: base(service)
		{
		}

		public ActionResult All(int? page)
		{
			Grid<MyCarForDisplay> grid = Service.GetMyCarsGrid(page);
			return View(grid);
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
			Service.Create(entity);
			return RedirectToAction("All");
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
					errorMessage = "My car has not been found"
				});
			}
			return Json(new { success = true });
		}

		// todo: return lower case json
		public JsonResult GetCarModelsByMake(int makeId)
		{
			List<SelectListItem> carModels = Service.GetCarModelsSelectListByMake(makeId);
			return Json(carModels, JsonRequestBehavior.AllowGet);
		}
	}
}