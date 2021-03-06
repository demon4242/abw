﻿using System.Collections.Generic;
using System.Linq;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Contracts;
using abw.DAL.Entities;

namespace abw.BusinessLogic
{
	public class CarsService : CrudService<Car>, ICarsService
	{
		public CarsService(IUnitOfWork uow)
			: base(uow)
		{
		}

		protected override IRepository<Car> Repository
		{
			get
			{
				return Uow.Cars;
			}
		}

		public List<Car> GetAll()
		{
			List<Car> cars = Uow.Cars.GetAll();
			return cars;
		}

		public List<Car> GetByMakeAndModel(string make, string model)
		{
			string lowerMake = make.ToLower();
			IEnumerable<Car> cars = Uow.Cars.GetAll().Where(m => m.Make.ToLower() == lowerMake);
			if (!string.IsNullOrWhiteSpace(model))
			{
				string lowerModel = model.ToLower();
				cars = cars.Where(m => m.Model.ToLower() == lowerModel);
			}

			List<Car> result = cars.ToList();
			return result;
		}

		public Car Get(string make, string model, int yearFrom, int? yearTo)
		{
			Car car = Uow.Cars.Get(make, model, yearFrom, yearTo);
			return car;
		}

		public bool CheckIfCarExists(Car car, Car originalCar = null)
		{
			Car carFromDb = Uow.Cars.GetAll().SingleOrDefault(m => m.Make.ToLower() == car.Make.ToLower()
				&& m.Model.ToLower() == car.Model.ToLower()
				&& m.YearFrom == car.YearFrom
				&& (m.YearTo == car.YearTo
					// next line is required
					|| m.YearTo == null && car.YearTo == null));

			if (carFromDb == null)
			{
				return false;
			}

			// check if original car is equal to car from db (it might happen in while editing)
			if (originalCar != null
					&& carFromDb.Make.ToLower() == originalCar.Make.ToLower()
					&& carFromDb.Model.ToLower() == originalCar.Model.ToLower()
					&& carFromDb.YearFrom == originalCar.YearFrom
					&& carFromDb.YearTo == originalCar.YearTo
				)
			{
				return false;
			}

			return true;
		}

		public void Delete(Car car)
		{
			Uow.Cars.Delete(car);
		}
	}
}
