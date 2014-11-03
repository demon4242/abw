using System;
using System.Web.Mvc;

namespace abw.Controllers
{
	public abstract class BaseController<T> : Controller where T : class, IDisposable
	{
		protected readonly T Service;

		protected BaseController(T service)
		{
			Service = service;
		}

		protected override void Dispose(bool disposing)
		{
			Service.Dispose();
			base.Dispose(disposing);
		}
	}
}