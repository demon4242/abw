using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using abw.Attributes.Validation;
using abw.Common;
using abw.DAL.Entities;
using abw.Resources;
using abw.ViewModels.MyCars;
using Newtonsoft.Json;

namespace abw.ViewModels
{
	public class MyCarViewModel : MyCarBase
	{
		public MyCarViewModel()
		{
			Makes = new List<SelectListItem>();
			Models = new List<SelectListItem>();
		}

		public List<SelectListItem> Makes { get; set; }

		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[Display(ResourceType = typeof(DisplayNames), Name = "Make")]
		public int MakeId { get; set; }

		public List<SelectListItem> Models { get; set; }

		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[Display(ResourceType = typeof(DisplayNames), Name = "Model")]
		public int ModelId { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Year")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		public override int Year { get; set; }

		[Display(ResourceType = typeof(DisplayNames), Name = "Photo")]
		[Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = "Required")]
		[ValidFileExtensions(Constants.ValidPhotoExtensions)]
		[MaxFileSize(Constants.MaxFileSize)]
		[JsonIgnore]
		public HttpPostedFileBase Photo { get; set; }

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

			myCar.Id = Id;
			myCar.CarId = ModelId;
			myCar.Year = Year;
			myCar.Photo = Photo.FileName;

			return myCar;
		}
	}
}