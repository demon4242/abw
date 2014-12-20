using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using abw.Common;
using abw.DAL.Entities;
using abw.Resources;
using abw.ViewModels.ValidationAttributes;

namespace abw.ViewModels
{
	public class CarViewModel : CarForGrid
	{
		public CarViewModel()
		{
			CurrentPhotos = new Dictionary<string, bool>();
		}

		[Display(ResourceType = typeof(DisplayNames), Name = "Make")]
		[RequiredRestriction]
		[StringLengthRestriction(Constants.MaxStringLength)]
		public override string Make { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Model")]
		[RequiredRestriction]
		[StringLengthRestriction(Constants.MaxStringLength)]
		public override string Model { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Year")]
		[RequiredRestriction]
		public override int YearFrom { get; set; }

		[NotLessThan("YearFrom")]
		[Display(ResourceType = typeof(DisplayNames), Name = "Year")]
		public override int? YearTo { get; set; }

		public List<SelectListItem> Years
		{
			get
			{
				const int minYear = 1960;

				List<SelectListItem> years = new List<SelectListItem>();
				for (int i = DateTime.Now.Year; i >= minYear; i--)
				{
					string year = i.ToString();
					SelectListItem selectListItem = new SelectListItem
					{
						Value = year,
						Text = year
					};
					years.Add(selectListItem);
				}
				return years;
			}
		}

		public Dictionary<string, bool> CurrentPhotos { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Photos")]
		[ValidFileExtensions(Constants.ValidPhotoExtensions)]
		[MaxFileSize(Constants.MaxFileSize)]
		public List<HttpPostedFileBase> Photos { get; set; }

		public Car ToEntity()
		{
			Car car = new Car();

			car.Id = Id;
			car.Make = Make.Trim();
			car.Model = Model.Trim();
			car.YearFrom = YearFrom;
			car.YearTo = YearTo;

			return car;
		}
	}
}