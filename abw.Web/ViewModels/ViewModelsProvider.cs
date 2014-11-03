using System.Collections.Generic;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;

namespace abw.ViewModels
{
	public static class ViewModelsProvider
	{
		#region Public

		public static Grid<CarForDisplay> GetCarsGrid(this ICarService carService, int page = 1)
		{
			int totalCount;
			List<Car> cars = carService.GetAll(page, out totalCount);
			List<CarForDisplay> list = cars.ConvertAll(ToDisplayViewModel);
			Grid<CarForDisplay> grid = new Grid<CarForDisplay>
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

			viewModel.Id = car.Id;
			viewModel.Make = car.Make;
			viewModel.Model = car.Model;
			viewModel.Year = car.Year;

			return viewModel;
		}

		#endregion Private
	}
}