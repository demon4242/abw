using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using abw.App_Start;
using abw.Controllers;
using abw.DAL;

namespace abw
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			BundleConfig.RegisterBundles(BundleTable.Bundles);

			Database.SetInitializer(new AbwDbInitializer());
		}

		protected void Application_Error(object sender, EventArgs e)
		{
			if (!Context.IsCustomErrorEnabled)
			{
				return;
			}

			Exception exception = Server.GetLastError();

			HttpException httpException = exception as HttpException ??
				new HttpException(500, "Internal Server Error", exception);

			Response.Clear();
			RouteData routeData = new RouteData();
			routeData.Values.Add("controller", "Errors");

			switch (httpException.GetHttpCode())
			{
				case 404:
					routeData.Values.Add("action", "PageNotFound");
					break;

				case 500:
					routeData.Values.Add("action", "InternalServerError");
					break;

				default:
					routeData.Values.Add("action", "GenericError");
					routeData.Values.Add("httpStatusCode", httpException.GetHttpCode());
					break;
			}

			Server.ClearError();

			IController controller = new ErrorsController();
			controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
		}
	}
}