using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using abw.DAL.Entities;
using abw.Resources;
using abw.ViewModels.MyCars;

namespace abw.ViewModels
{
	public class MyCarViewModel : MyCarBase
	{
		[Display(ResourceType = typeof(DisplayNames), Name = "Make")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages),
			ErrorMessageResourceName = "StringMaxLength")]
		public string Make { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Model")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[StringLength(Constants.MaxStringLength, ErrorMessageResourceType = typeof(ErrorMessages),
			ErrorMessageResourceName = "StringMaxLength")]
		public string Model { get; set; }

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

		public MyCar ToEntity()
		{
			MyCar myCar = new MyCar();

			// todo: implement

			return myCar;
		}
	}
}