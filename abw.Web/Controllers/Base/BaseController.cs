using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;

namespace abw.Controllers
{
	public abstract class BaseController<T> : Controller where T : class, IBaseService
	{
		protected readonly T Service;

		protected BaseController(T service)
		{
			Service = service;
		}
	}
}