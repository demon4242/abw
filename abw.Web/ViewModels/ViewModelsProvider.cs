using System.Collections.Generic;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Helpers;

namespace abw.ViewModels
{
	public static class ViewModelsProvider
	{
		#region Public

		public static Grid<CarForGrid> GetCarsGrid(this ICarService carService, int page = 1)
		{
			int totalCount;
			List<Car> cars = carService.GetAll(page, out totalCount);
			List<CarForGrid> list = cars.ConvertAll(ToGridViewModel);
			Grid<CarForGrid> grid = new Grid<CarForGrid>
			{
				List = list,
				TotalCount = totalCount
			};
			return grid;
		}

		public static List<CarForDisplay> GetCarsForDisplay(this ICarService carService)
		{
			List<Car> cars = carService.GetAll();
			List<CarForDisplay> result = cars.ConvertAll(ToDisplayViewModel);
			return result;
		}

		public static CarViewModel GetCar(this ICarService carService, int id)
		{
			Car car = carService.GetById(id);
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
			viewModel.Year = car.Year;

			return viewModel;
		}

		private static CarForDisplay ToDisplayViewModel(this Car car)
		{
			CarForDisplay viewModel = new CarForDisplay();

			viewModel.Make = car.Make;
			viewModel.Model = car.Model;
			viewModel.Year = car.Year;
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
			viewModel.Year = car.Year;

			return viewModel;
		}

		#endregion Private
	}
}