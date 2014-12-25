﻿using System.Net;
using System.Web.Mvc;

namespace abw.Web.Utilities.Attributes
{
	/// <summary>
	/// Restrics unauthorized users from access
	/// </summary>
	public class NonAuthorizeAttribute : AuthorizeAttribute
	{
		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (filterContext.HttpContext.User.Identity.IsAuthenticated)
			{
				// todo: default 404 is not being returned
				filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.NotFound);
			}
		}
	}
}