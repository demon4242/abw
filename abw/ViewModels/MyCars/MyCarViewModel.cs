using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using abw.Resources;
using abw.ViewModels.MyCars;

namespace abw.ViewModels
{
	public class MyCarViewModel : MyCarForDisplay
	{
		[Display(ResourceType = typeof(DisplayNames), Name = "Make")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public override string Make { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Model")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public override string Model { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Year")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public int Year { get; set; }

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
	}
}