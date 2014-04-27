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
			List<CarMake> cars = carService.GetAll(page);
			List<CarForDisplay> list = cars.ConvertAll(ToDisplayViewModel);
			Grid<CarForDisplay> grid = new Grid<CarForDisplay>
			{
				List = list
			};
			return grid;
		}

		public static CarViewModel GetEditCar(this ICarService carService, int id)
		{
			CarMake carMake = carService.GetById(id);
			CarViewModel viewModel = carMake.ToViewModel();
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

		private static CarViewModel ToViewModel(this CarMake carMake)
		{
			CarViewModel viewModel = new CarViewModel();

			viewModel.Id = carMake.Id;
			viewModel.Make = carMake.Name;
			viewModel.Models = carMake.Cars.Select(ToViewModel).ToList();

			return viewModel;
		}

		private static CarForDisplay ToDisplayViewModel(this CarMake carMake)
		{
			CarForDisplay viewModel = new CarForDisplay();

			viewModel.Id = carMake.Id;
			viewModel.Make = carMake.Name;
			viewModel.Models = carMake.Cars.Select(m => m.Model).ToList();

			return viewModel;
		}

		private static CarModelViewModel ToViewModel(Car car)
		{
			CarModelViewModel viewModel = new CarModelViewModel();

			viewModel.Id = car.Id;
			viewModel.Name = car.Model;

			return viewModel;
		}

		#endregion Car

		#region MyCar

		private static MyCarViewModel ToViewModel(this MyCar myCar)
		{
			MyCarViewModel viewModel = new MyCarViewModel();

			viewModel.Id = myCar.Id;
			viewModel.Make = myCar.Car.Make.Name;
			viewModel.Model = myCar.Car.Model;

			return viewModel;
		}

		private static MyCarForDisplay ToDisplayViewModel(this MyCar myCar)
		{
			MyCarForDisplay viewModel = new MyCarForDisplay();

			viewModel.Id = myCar.Id;
			viewModel.MakeAndModel = string.Format("{0} {1}", myCar.Car.Make.Name, myCar.Car.Model);
			viewModel.Year = myCar.Year;

			return viewModel;
		}

		#endregion MyCar

		#endregion Private
	}
}