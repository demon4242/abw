using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Helpers;
using abw.Resources;
using abw.ViewModels;

namespace abw.Controllers
{
	[Authorize]
	public class CarsController : BaseController<ICarsService>
	{
		public CarsController(ICarsService service)
			: base(service)
		{
		}

		public ActionResult Grid()
		{
			Grid<CarForGrid> grid = Service.GetCarsGrid();
			return View(grid);
		}

		/// <summary>
		/// Is used for continuous scrolling
		/// </summary>
		public JsonNetResult All(int page)
		{
			Grid<CarForGrid> grid = Service.GetCarsGrid(page);
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
				PrepareInvalidCarForView(ref car);
				return View(car);
			}
			Car entity = car.ToEntity();
			bool carExists = Service.CheckIfCarExists(entity);
			if (carExists)
			{
				ModelState.AddModelError(string.Empty, ErrorMessages.CarAlreadyExists);
				PrepareInvalidCarForView(ref car);
				return View(car);
			}
			Service.Create(entity);
			PhotoManager.Save(car);
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
				PrepareInvalidCarForView(ref car);
				return View(car);
			}

			Car entity = car.ToEntity();
			// need to get original name before entity is updated
			Car originalEntity = Service.GetById(car.Id);

			bool carExists = Service.CheckIfCarExists(entity, originalEntity);
			if (carExists)
			{
				ModelState.AddModelError(string.Empty, ErrorMessages.CarAlreadyExists);
				PrepareInvalidCarForView(ref car);
				return View(car);
			}

			Service.Update(entity);

			string originalName = PhotoManager.GetCarName(originalEntity);
			PhotoManager.Update(originalName, car);

			return RedirectToAction("Grid");
		}

		[HttpPost]
		public JsonResult Delete(int id)
		{
			Car car = Service.GetById(id);
			bool success = Service.Delete(id);
			if (success)
			{
				PhotoManager.Delete(car);
				return Json(new { success = true });
			}

			return Json(new
			{
				success = false,
				errorMessage = ErrorMessages.CarNotFound
			});
		}

		/// <summary>
		/// Prepares <see cref="CarViewModel"/> for a view if it has validation errors
		/// </summary>
		private void PrepareInvalidCarForView(ref CarViewModel car)
		{
			// hack in order to make 'HtmlHelpers.ToJs' method work
			car.Photos = null;
		}
	}
}