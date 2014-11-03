﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using abw.Attributes.Validation;
using abw.Common;
using abw.DAL.Entities;
using abw.Resources;

namespace abw.ViewModels
{
	public class CarViewModel : CarForDisplay
	{
		[Display(ResourceType = typeof(DisplayNames), Name = "Make")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringMaxLength")]
		public override string Make { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Model")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "StringMaxLength")]
		public override string Model { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Year")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public override int Year { get; set; }

		public List<SelectListItem> Years
		{
			get
			{
				List<SelectListItem> years = new List<SelectListItem>();
				for (int i = DateTime.Now.Year; i >= 1960; i--)
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

		[Display(ResourceType = typeof(DisplayNames), Name = "Photo")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[ValidFileExtensions(Constants.ValidPhotoExtensions)]
		[MaxFileSize(Constants.MaxFileSize)]
		public HttpPostedFileBase Photo { get; set; }

		public Car ToEntity()
		{
			Car car = new Car();

			car.Id = Id;
			car.Make = Make;
			car.Model = Model;
			car.Year = Year;
			car.Photo = Photo.FileName;

			return car;
		}
	}
}