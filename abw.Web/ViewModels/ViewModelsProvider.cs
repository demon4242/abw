using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;

namespace abw.ViewModels
{
	public static class ViewModelsProvider
	{
		#region Public

		#region Car

		public static Grid<CarForDisplay> GetCarsGrid(this ICarService carService, int? page)
		{
			List<Car> cars = carService.GetAll(page);
			List<CarForDisplay> list = cars.ConvertAll(ToDisplayViewModel);
			Grid<CarForDisplay> grid = new Grid<CarForDisplay>
			{
				List = list
			};
			return grid;
		}

		public static CarViewModel GetEditCar(this ICarService carService, int id)
		{
			Car car = carService.GetById(id);
			CarViewModel viewModel = car.ToViewModel();
			return viewModel;
		}

		#endregion Car

		#region MyCar

		public static Grid<MyCarForDisplay> GetMyCarsGrid(this IMyCarService myCarService, int? page)
		{
			List<MyCar> myCars = myCarService.GetAll(page);
			List<MyCarForDisplay> list = myCars.ConvertAll(ToDisplayViewModel);
			Grid<MyCarForDisplay> grid = new Grid<MyCarForDisplay>
			{
				List = list
			};
			return grid;
		}

		public static MyCarViewModel GetEditCar(this IMyCarService myCarService, int id)
		{
			MyCar myCar = myCarService.GetById(id);
			MyCarViewModel viewModel = myCar.ToViewModel();
			return viewModel;
		}

		#endregion MyCar

		#endregion Public

		#region Private

		#region Car

		private static CarViewModel ToViewModel(this Car car)
		{
			CarViewModel viewModel = new CarViewModel();

			viewModel.Id = car.Id;
			viewModel.Make = car.Make;
			viewModel.Models = car.Models.Select(ToViewModel).ToList();

			return viewModel;
		}

		private static CarForDisplay ToDisplayViewModel(this Car car)
		{
			CarForDisplay viewModel = new CarForDisplay();

			viewModel.Id = car.Id;
			viewModel.Make = car.Make;
			viewModel.Models = car.Models.Select(m => m.Name).ToList();

			return viewModel;
		}

		private static CarModelViewModel ToViewModel(CarModel carModel)
		{
			CarModelViewModel viewModel = new CarModelViewModel();

			viewModel.Id = carModel.Id;
			viewModel.Name = carModel.Name;

			return viewModel;
		}

		#endregion Car

		#region MyCar

		private static MyCarViewModel ToViewModel(this MyCar myCar)
		{
			MyCarViewModel viewModel = new MyCarViewModel();

			viewModel.Id = myCar.Id;
			viewModel.Make = myCar.CarModel.Car.Make;
			viewModel.Model = myCar.CarModel.Name;

			return viewModel;
		}

		private static MyCarForDisplay ToDisplayViewModel(this MyCar myCar)
		{
			MyCarForDisplay viewModel = new MyCarForDisplay();

			viewModel.Id = myCar.Id;
			viewModel.MakeAndModel = string.Format("{0} {1}", myCar.CarModel.Car.Make, myCar.CarModel.Name);
			viewModel.Year = myCar.Year;

			return viewModel;
		}

		#endregion MyCar

		#endregion Private
	}
}