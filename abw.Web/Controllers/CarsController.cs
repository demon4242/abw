using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Resources;
using abw.ViewModels;
using abw.Web.Utilities;
using abw.Web.Utilities.Helpers;

namespace abw.Controllers
{
	[Authorize]
	[RoutePrefix("admin/cars")]
	public class CarsController : BaseController<ICarsService>
	{
		public CarsController(ICarsService service)
			: base(service)
		{
		}

		[Route("")]
		public ActionResult Grid()
		{
			Grid<CarForGrid> grid = Service.GetCarsGrid();
			return View(grid);
		}

		/// <summary>
		/// Is used for continuous scrolling
		/// </summary>
		[Route("{page}")]
		public JsonNetResult All(int page)
		{
			Grid<CarForGrid> grid = Service.GetCarsGrid(page);
			return new JsonNetResult(grid);
		}

		[Route("new")]
		public ActionResult New()
		{
			CarViewModel car = new CarViewModel();
			return View(car);
		}

		[HttpPost]
		[Route("new")]
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

		[Route("edit/{id}")]
		public ActionResult Edit(int id)
		{
			CarViewModel car = Service.GetCar(id);
			return View(car);
		}

		[HttpPost]
		[Route("edit")]
		public ActionResult Edit(CarViewModel car)
		{
			if (!ModelState.IsValid)
			{
				PrepareInvalidCarForView(ref car);
				return View(car);
			}

			Car entity = car.ToEntity();
			Car originalEntity = Service.GetById(car.Id);

			bool carExists = Service.CheckIfCarExists(entity, originalEntity);
			if (carExists)
			{
				ModelState.AddModelError(string.Empty, ErrorMessages.CarAlreadyExists);
				PrepareInvalidCarForView(ref car);
				return View(car);
			}

			// need to get original name before entity is updated
			string originalName = PhotoManager.GetCarName(originalEntity);
			Service.Update(entity);

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