using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;

namespace abw.ViewModels
{
	public static class ViewModelsProvider
	{
		#region Public

		public static List<string> GetMyCarsForDisplay(this IHomeService homeService)
		{
			List<MyCar> myCars = homeService.GetMyCars();
			List<string> result = myCars.Select(m => string.Format("{0} {1} {2}", m.Car.Make.Name, m.Car.Model, m.Year)).ToList();
			return result;
		}

		#region Car

		public static Grid<CarForDisplay> GetCarsGrid(this ICarService carService, int page = 1)
		{
			int totalCount;
			List<CarMake> cars = carService.GetAll(page, out totalCount);
			List<CarForDisplay> list = cars.ConvertAll(ToDisplayViewModel);
			Grid<CarForDisplay> grid = new Grid<CarForDisplay>
			{
				List = list,
				TotalCount = totalCount
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

		public static Grid<MyCarForDisplay> GetMyCarsGrid(this IMyCarService myCarService, int page = 1)
		{
			int totalCount;
			List<MyCar> myCars = myCarService.GetAll(page, out totalCount);
			List<MyCarForDisplay> list = myCars.ConvertAll(ToDisplayViewModel);
			Grid<MyCarForDisplay> grid = new Grid<MyCarForDisplay>
			{
				List = list,
				TotalCount = totalCount
			};
			return grid;
		}

		public static MyCarViewModel GetNewCar(this IMyCarService myCarService)
		{
			List<SelectListItem> makes = myCarService.GetAllCarMakesSelectList();

			MyCarViewModel viewModel = new MyCarViewModel
			{
				Makes = makes
			};
			return viewModel;
		}

		public static List<SelectListItem> GetCarModelsSelectListByMake(this IMyCarService myCarService, int makeId)
		{
			List<Car> carModels = myCarService.GetCarModelsByMake(makeId);
			List<SelectListItem> result = carModels.ConvertAll(m => new SelectListItem
			{
				Value = m.Id.ToString(),
				Text = m.Model
			});
			return result;
		}

		public static MyCarViewModel GetEditCar(this IMyCarService myCarService, int id)
		{
			MyCar myCar = myCarService.GetById(id);
			List<SelectListItem> makes = myCarService.GetAllCarMakesSelectList();
			List<SelectListItem> models = myCarService.GetCarModelsSelectListByMake(myCar.Car.MakeId);

			MyCarViewModel viewModel = myCar.ToViewModel();

			viewModel.Makes = makes;
			viewModel.Models = models;

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
			viewModel.Models = carMake.Cars.Select(m => m.Model).OrderBy(m => m).ToList();

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
			viewModel.MakeId = myCar.Car.MakeId;
			viewModel.ModelId = myCar.CarId;
			viewModel.Year = myCar.Year;

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

		public static List<SelectListItem> GetAllCarMakesSelectList(this IMyCarService myCarService)
		{
			List<CarMake> carMakes = myCarService.GetAllCarMakes();

			List<SelectListItem> makes = carMakes.ConvertAll(m => new SelectListItem
			{
				Value = m.Id.ToString(),
				Text = m.Name.ToString()
			});
			return makes;
		}

		#endregion MyCar

		#endregion Private
	}
}