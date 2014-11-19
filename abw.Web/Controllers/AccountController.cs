using System.Web.Mvc;
using System.Web.Security;
using abw.Attributes;
using abw.BusinessLogic.Interfaces;
using abw.DAL.Entities;
using abw.Resources;
using abw.ViewModels;

namespace abw.Controllers
{
	[RoutePrefix("account")]
	public class AccountController : BaseController<IAccountService>
	{
		public AccountController(IAccountService service)
			: base(service)
		{
		}

		// todo: implement logIn popup
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
			return RedirectToAction("Index", "Home");
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