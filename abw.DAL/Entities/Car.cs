﻿using System.ComponentModel.DataAnnotations;
using abw.Common;

namespace abw.DAL.Entities
{
	public class Car : BaseEntity
	{
		[Required]
		public int MakeId { get; set; }

		public CarMake Make { get; set; }

		[Required]
		[MaxLength(Constants.MaxStringLength)]
		public string Model { get; set; }
	}
}
