using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.ViewModels;
using abw.Web.Utilities.Helpers;

namespace abw.Web.Utilities
{
	public static class ViewModelsProvider
	{
		#region Public

		public static Grid<CarForGrid> GetCarsGrid(this ICarsService carsService, int page = 1)
		{
			int totalCount;
			List<Car> cars = carsService.GetAll(page, out totalCount);
			List<CarForGrid> list = cars.ConvertAll(ToGridViewModel);
			Grid<CarForGrid> grid = new Grid<CarForGrid>
			{
				List = list,
				TotalCount = totalCount
			};
			return grid;
		}

		public static CarForDisplay GetCarForDisplay(this ICarsService carsService, string make, string model, int yearFrom, int? yearTo)
		{
			Car car = carsService.Get(make, model, yearFrom, yearTo);
			CarForDisplay carForDisplay = car.ToDisplayViewModel();
			return carForDisplay;
		}

		public static List<CarForFullDisplay> GetCarsForFullDisplay(this ICarsService carsService)
		{
			List<Car> cars = carsService.GetAll();
			List<CarForFullDisplay> result = cars.ConvertAll(ToFullDisplayViewModel);
			return result;
		}

		public static List<CarForFullDisplay> GetCarsForFullDisplay(this ICarsService carsService, string make, string model = null)
		{
			List<Car> cars = carsService.GetByMakeAndModel(make, model);
			List<CarForFullDisplay> result = cars.ConvertAll(ToFullDisplayViewModel);
			return result;
		}

		public static EditCarViewModel GetCar(this ICarsService carsService, string make, string model, int yearFrom, int? yearTo)
		{
			Car car = carsService.Get(make, model, yearFrom, yearTo);
			EditCarViewModel viewModel = car.ToViewModel();
			return viewModel;
		}

		public static List<CarTreeItem> GetCarsTree(this ICarsService carsService)
		{
			List<Car> cars = carsService.GetAll();
			List<CarTreeItem> carsTree = new List<CarTreeItem>();
			foreach (Car car in cars)
			{
				CarTreeItem carTreeItem = carsTree.SingleOrDefault(m => m.Make == car.Make);
				if (carTreeItem != null)
				{
					if (!carTreeItem.Models.Contains(car.Model))
					{
						carTreeItem.Models.Add(car.Model);
					}
				}
				else
				{
					carTreeItem = new CarTreeItem
					{
						Make = car.Make,
						Models = new List<string>
						{
							car.Model
						}
					};
					carsTree.Add(carTreeItem);
				}
			}
			return carsTree;
		}

		#endregion Public

		#region Private

		private static EditCarViewModel ToViewModel(this Car car)
		{
			EditCarViewModel viewModel = new EditCarViewModel();

			viewModel.Make = car.Make;
			viewModel.Model = car.Model;
			viewModel.YearFrom = car.YearFrom;
			viewModel.YearTo = car.YearTo;
			List<string> paths = PhotoManager.Get(car);
			viewModel.CurrentPhotos = paths.ToDictionary(m => m, m => default(bool));

			viewModel.OriginalCar = new CarForGrid
			{
				Make = car.Make,
				Model = car.Model,
				YearFrom = car.YearFrom,
				YearTo = car.YearTo
			};

			return viewModel;
		}

		private static CarForDisplay ToDisplayViewModel(this Car car)
		{
			if (car == null)
			{
				return null;
			}

			CarForFullDisplay viewModel = new CarForFullDisplay();

			viewModel.Name = GetCarName(car);
			List<string> photos = PhotoManager.Get(car);
			viewModel.Photos = photos;

			return viewModel;
		}

		private static CarForFullDisplay ToFullDisplayViewModel(this Car car)
		{
			CarForFullDisplay viewModel = new CarForFullDisplay();

			viewModel.Make = car.Make;
			viewModel.Model = car.Model;
			viewModel.YearFrom = car.YearFrom;
			viewModel.YearTo = car.YearTo;
			viewModel.Name = GetCarName(car);
			List<string> photos = PhotoManager.Get(car);
			viewModel.Photos = photos;

			return viewModel;
		}

		private static CarForGrid ToGridViewModel(this Car car)
		{
			CarForGrid viewModel = new CarForGrid();

			viewModel.Make = car.Make;
			viewModel.Model = car.Model;
			viewModel.YearFrom = car.YearFrom;
			viewModel.YearTo = car.YearTo;

			return viewModel;
		}

		private static string GetCarName(Car car)
		{
			string yearTo = car.YearTo.HasValue
				? car.YearTo.ToString()
				: "настоящее время";
			string name = $"{car.Make} {car.Model} {car.YearFrom} - {yearTo}";
			return name;
		}

		#endregion Private
	}
}