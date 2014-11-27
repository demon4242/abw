using System.Net;
using System.Web.Mvc;
using System.Web.WebPages;

namespace abw.Web.Utilities.Attributes
{
	/// <summary>
	/// Restrics authorized users from access
	/// </summary>
	public class NonAuthorizeAttribute : AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (filterContext.HttpContext.User.Identity.IsAuthenticated)
			{
				// todo: blank page is being returned instead of default 404 page
				filterContext.HttpContext.Response.SetStatus(HttpStatusCode.NotFound);
			}
		}
	}
}