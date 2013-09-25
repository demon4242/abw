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
			MyCar myCar = new MyCar();
			return View(myCar);
		}

		[HttpPost]
		public ActionResult New(MyCar myCar)
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
		public ActionResult Edit(MyCar myCar)
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