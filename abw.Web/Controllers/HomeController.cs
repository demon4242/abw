using System.Collections.Generic;
using System.Web.Mvc;
using abw.BusinessLogic.Interfaces;
using abw.ViewModels;

namespace abw.Controllers
{
	public class HomeController : BaseController<IHomeService>
	{
		public HomeController(IHomeService service)
			: base(service)
		{
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult CarsCatalogue()
		{
			List<string> myCars = Service.GetMyCarsForDisplay();
			return View(myCars);
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contacts()
		{
			return View();
		}
	}
}
