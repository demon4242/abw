using System.Web.Mvc;
using System.Web.Routing;

namespace abw.Web.Utilities.Attributes
{
	public abstract class BaseAuthorizeAttribute : AuthorizeAttribute
	{
		protected ActionResult ReturnPageNoFound()
		{
			ActionResult pageNotFound = new RedirectToRouteResult(
				new RouteValueDictionary(
					new
					{
						controller = "errors",
						action = "pageNotFound"
					})
				);
			return pageNotFound;
		}
	}
}
