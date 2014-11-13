using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Helpers;

namespace abw.ViewModels
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

		public static CarForDisplay GetCarForDisplay(this ICarsService carsService, int carId)
		{
			Car car = carsService.GetById(carId);
			CarForDisplay carForDisplay = car.ToDisplayViewModel();
			return carForDisplay;
		}

		public static List<CarForDisplay> GetCarsForDisplay(this ICarsService carsService)
		{
			List<Car> cars = carsService.GetAll();
			List<CarForDisplay> result = cars.ConvertAll(ToDisplayViewModel);
			return result;
		}

		public static List<CarForDisplay> GetCarsForDisplay(this ICarsService carsService, string make)
		{
			List<Car> cars = carsService.GetByMake(make);
			List<CarForDisplay> result = cars.ConvertAll(ToDisplayViewModel);
			return result;
		}

		public static CarViewModel GetCar(this ICarsService carsService, int id)
		{
			Car car = carsService.GetById(id);
			CarViewModel viewModel = car.ToViewModel();
			return viewModel;
		}

		#endregion Public

		#region Private

		private static CarViewModel ToViewModel(this Car car)
		{
			CarViewModel viewModel = new CarViewModel();

			viewModel.Id = car.Id;
			viewModel.Make = car.Make;
			viewModel.Model = car.Model;
			viewModel.YearFrom = car.YearFrom;
			viewModel.YearTo = car.YearTo;
			List<string> paths = PhotoManager.Get(car);
			viewModel.CurrentPhotos = paths.ToDictionary(m => m, m => default(bool));

			return viewModel;
		}

		private static CarForDisplay ToDisplayViewModel(this Car car)
		{
			const string nullYearToReplacer = "настоящее время";

			CarForDisplay viewModel = new CarForDisplay();

			viewModel.Id = car.Id;
			string yearTo = car.YearTo.HasValue
				? car.YearTo.ToString()
				: nullYearToReplacer;
			viewModel.Name = string.Format("{0} {1} {2} - {3}", car.Make, car.Model, car.YearFrom, yearTo);
			List<string> photos = PhotoManager.Get(car);
			viewModel.Photos = photos;

			return viewModel;
		}

		private static CarForGrid ToGridViewModel(this Car car)
		{
			CarForGrid viewModel = new CarForGrid();

			viewModel.Id = car.Id;
			viewModel.Make = car.Make;
			viewModel.Model = car.Model;
			viewModel.YearFrom = car.YearFrom;
			viewModel.YearTo = car.YearTo;

			return viewModel;
		}

		#endregion Private
	}
}