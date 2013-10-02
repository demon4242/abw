using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using abw.DAL.Entities;
using abw.ViewModels;

namespace abw.Controllers
{
	// todo: use Ninject
	public class CarsController : BaseController
	{
		public ActionResult All(int? page)
		{
			List<Car> cars = Uow.Cars.GetAll().ToList();
			List<CarForDisplay> list = cars.ConvertAll(ViewModelsProvider.ToDisplayViewModel);
			Grid<CarForDisplay> grid = new Grid<CarForDisplay>
			{
				List = list
			};
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
			Uow.Cars.Create(entity);
			Uow.Save();
			return RedirectToAction("All");
		}

		public ActionResult Edit(long id)
		{
			Car car = Uow.Cars.GetById(id);
			if (car == null)
			{
				throw new NotImplementedException();
			}
			CarViewModel viewModel = car.ToViewModel();
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(CarViewModel car)
		{
			if (!ModelState.IsValid)
			{
				return View(car);
			}
			Car entity = car.ToEntity();
			Uow.Cars.Update(entity);
			Uow.Save();
			return RedirectToAction("All");
		}

		public JsonResult Delete(long id)
		{
			bool success = Uow.Cars.Delete(id);
			if (!success)
			{
				return Json(new
				{
					success = false,
					errorMessage = "Car has not been found"
				});
			}
			Uow.Save();
			return Json(new { success = true });
		}
	}
}