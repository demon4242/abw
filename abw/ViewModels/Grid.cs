using System.Collections.Generic;

namespace abw.ViewModels
{
	public class Grid<T> where T : class
	{
		public List<T> List { get; set; }

		public int Page { get; set; }
	}
}