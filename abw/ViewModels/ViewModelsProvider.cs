using System.Linq;
using abw.DAL.Entities;

namespace abw.ViewModels
{
	public static class ViewModelsProvider
	{
		#region Car

		public static CarViewModel ToViewModel(this Car car)
		{
			CarViewModel viewModel = new CarViewModel();

			viewModel.Id = car.Id;
			viewModel.Make = car.Make;
			viewModel.Models = car.Models.Select(ToViewModel).ToList();

			return viewModel;
		}

		public static CarForDisplay ToDisplayViewModel(this Car car)
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

		public static MyCarViewModel ToViewModel(this MyCar myCar)
		{
			MyCarViewModel viewModel = new MyCarViewModel();

			viewModel.Id = myCar.Id;
			viewModel.Make = myCar.CarModel.Car.Make;
			viewModel.Model = myCar.CarModel.Name;

			return viewModel;
		}

		public static MyCarForDisplay ToDisplayViewModel(this MyCar myCar)
		{
			MyCarForDisplay viewModel = new MyCarForDisplay();

			viewModel.Id = myCar.Id;
			viewModel.MakeAndModel = string.Format("{0} {1}", myCar.CarModel.Car.Make, myCar.CarModel.Name);
			viewModel.Year = myCar.Year;

			return viewModel;
		}

		#endregion MyCar
	}
}