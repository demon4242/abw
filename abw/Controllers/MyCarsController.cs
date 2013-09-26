using System;
using System.Web.Mvc;
using abw.ViewModels;

namespace abw.Controllers
{
	public class MyCarsController : Controller
	{
		public ActionResult All(int? page)
		{
			return View();
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
			// todo
			return RedirectToAction("All");
		}

		public ActionResult Edit(long id)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public ActionResult Edit(MyCarViewModel myCar)
		{
			if (!ModelState.IsValid)
			{
				return View(myCar);
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