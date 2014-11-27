using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Resources;
using abw.ViewModels;
using abw.Web.Utilities.Attributes;
using abw.Web.Utilities.Helpers;

namespace abw.Controllers
{
	[RoutePrefix("account")]
	public class AccountController : BaseController<IAccountService>
	{
		public AccountController(IAccountService service)
			: base(service)
		{
		}

		[NonAuthorize]
		[Route("signIn")]
		public ActionResult SignIn(string returnUrl)
		{
			SignInModel signInModel = new SignInModel();
			signInModel.ReturnUrl = returnUrl;
			return View(signInModel);
		}

		[HttpPost]
		[NonAuthorize]
		[Route("signIn")]
		public ActionResult SignIn(SignInModel signInModel)
		{
			if (!ModelState.IsValid)
			{
				return View(signInModel);
			}
			User user = Service.GetUser(signInModel.Name, signInModel.Password);
			if (user == null)
			{
				ModelState.AddModelError(string.Empty, ErrorMessages.InvalidUsernameOrPassword);
				return View(signInModel);
			}
			FormsAuthentication.SetAuthCookie(signInModel.Name, true);

			if (!string.IsNullOrEmpty(signInModel.ReturnUrl))
			{
				return Redirect(signInModel.ReturnUrl);
			}
			return RedirectToAction("Grid", "Cars");
		}

		[HttpPost]
		[NonAuthorize]
		[Route("signInModal")]
		public JsonNetResult SignInModal(SignInModal signInModal)
		{
			if (!ModelState.IsValid)
			{
				List<string> errorMessages = CommonHelpers.GetErrorMessages(ModelState);
				return new JsonNetResult(new { success = false, errorMessages });
			}
			User user = Service.GetUser(signInModal.Name, signInModal.Password);
			if (user == null)
			{
				List<string> errorMessages = new List<string> { ErrorMessages.InvalidUsernameOrPassword };
				return new JsonNetResult(new { success = false, errorMessages });
			}
			FormsAuthentication.SetAuthCookie(signInModal.Name, true);

			string returnUrl = Url.Action("Grid", "Cars");
			return new JsonNetResult(new { success = true, returnUrl });
		}

		[Authorize]
		[Route("signOut")]
		public ActionResult SignOut(string returnUrl)
		{
			FormsAuthentication.SignOut();
			return Redirect(returnUrl);
		}
	}
}