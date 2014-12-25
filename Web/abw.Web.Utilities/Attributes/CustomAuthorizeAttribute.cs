using System.Net;
using System.Web.Mvc;

namespace abw.Web.Utilities.Attributes
{
	public class CustomAuthorizeAttribute : AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
			{
				filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.NotFound);
			}
		}
	}
}
