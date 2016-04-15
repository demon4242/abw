using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Resources;
using abw.ViewModels;
using abw.Web.Utilities;
using abw.Web.Utilities.Attributes;
using abw.Web.Utilities.Helpers;

namespace abw.Controllers
{
	[CustomAuthorize]
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
				car = PrepareInvalidCarForView(car);
				return View(car);
			}
			Car entity = car.ToEntity();
			bool carExists = Service.CheckIfCarExists(entity);
			if (carExists)
			{
				ModelState.AddModelError(string.Empty, ErrorMessages.CarAlreadyExists);
				car = PrepareInvalidCarForView(car);
				return View(car);
			}
			Service.Create(entity);
			PhotoManager.Save(car);
			return RedirectToAction("Grid");
		}

		[Route("edit/{make}/{model}/{yearFrom:int}/{yearTo:int?}")]
		public ActionResult Edit(string make, string model, int yearFrom, int? yearTo)
		{
			EditCarViewModel car = Service.GetCar(make, model, yearFrom, yearTo);
			return View(car);
		}

		[HttpPost]
		[Route("edit")]
		public ActionResult Edit(EditCarViewModel car)
		{
			if (!ModelState.IsValid)
			{
				car = (EditCarViewModel)PrepareInvalidCarForView(car);
				return View(car);
			}

			Car entity = car.ToEntity();
			CarForGrid originalCar = car.OriginalCar;
			Car originalEntity = Service.Get(originalCar.Make, originalCar.Model, originalCar.YearFrom, originalCar.YearTo);

			bool carExists = Service.CheckIfCarExists(entity, originalEntity);
			if (carExists)
			{
				ModelState.AddModelError(string.Empty, ErrorMessages.CarAlreadyExists);
				car = (EditCarViewModel)PrepareInvalidCarForView(car);
				return View(car);
			}

			// need to get original name before entity is updated
			string originalName = PhotoManager.GetCarName(originalEntity);
			Service.Update(entity, originalEntity);

			PhotoManager.Update(originalName, car);

			return RedirectToAction("Grid");
		}

		// todo: use 'CarForGrid' viewModel as input parameter
		[HttpPost]
		[Route("delete/{make}/{model}/{yearFrom:int}/{yearTo:int?}")]
		public JsonResult Delete(string make, string model, int yearFrom, int? yearTo)
		{
			Car car = Service.Get(make, model, yearFrom, yearTo);
			if (car == null)
			{
				return Json(new
				{
					success = false,
					errorMessage = ErrorMessages.CarNotFound
				});
			}

			Service.Delete(car);
			PhotoManager.Delete(car);
			return Json(new { success = true });
		}

		/// <summary>
		/// Prepares <see cref="CarViewModel"/> for a view if it has validation errors
		/// </summary>
		private CarViewModel PrepareInvalidCarForView(CarViewModel car)
		{
			// hack in order to make 'HtmlHelpers.ToJs' method work
			car.Photos = null;
			return car;
		}
	}
}