using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using abw.DAL.Entities;
using abw.ViewModels;

namespace abw.Controllers
{
	public class MyCarsController : BaseController
	{
		public ActionResult All(int? page)
		{
			List<MyCar> myCars = Uow.MyCars.GetAll().ToList();
			List<MyCarForDisplay> list = myCars.ConvertAll(ViewModelsProvider.ToDisplayViewModel);
			Grid<MyCarForDisplay> grid = new Grid<MyCarForDisplay>
			{
				List = list
			};
			return View(grid);
		}

		public ActionResult New()
		{
			MyCarViewModel myCar = new MyCarViewModel();
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
			Uow.MyCars.Create(entity);
			Uow.Save();
			return RedirectToAction("All");
		}

		public ActionResult Edit(long id)
		{
			MyCar myCar = Uow.MyCars.GetById(id);
			if (myCar == null)
			{
				throw new NotImplementedException();
			}
			MyCarViewModel viewModel = myCar.ToViewModel();
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Edit(MyCarViewModel myCar)
		{
			if (!ModelState.IsValid)
			{
				return View(myCar);
			}
			MyCar entity = myCar.ToEntity();
			Uow.MyCars.Update(entity);
			Uow.Save();
			return RedirectToAction("All");
		}

		public JsonResult Delete(long id)
		{
			bool success = Uow.MyCars.Delete(id);
			if (!success)
			{
				return Json(new
				{
					success = false,
					errorMessage = "My car has not been found"
				});
			}
			Uow.Save();
			return Json(new { success = true });
		}
	}
}