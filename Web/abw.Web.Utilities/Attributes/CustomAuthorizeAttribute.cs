using System.Web.Mvc;

namespace abw.Web.Utilities.Attributes
{
	public class CustomAuthorizeAttribute : BaseAuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
			{
				filterContext.Result = ReturnPageNoFound();
			}
		}
	}
}
