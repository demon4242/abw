using System.Web.Mvc;
using System.Web.Security;
using abw.BusinessLogic;
using abw.DAL.Entities;
using abw.Resources;
using abw.ViewModels;

namespace abw.Controllers
{
	public class AccountController : BaseController<AccountService>
	{
		public AccountController(AccountService service)
			: base(service)
		{
		}

		// todo: implement logIn popup
		// todo: add [NonAuthorize]
		public ActionResult SignIn()
		{
			return View(new SignIn());
		}

		// todo: add [NonAuthorize]
		[HttpPost]
		public ActionResult SignIn(SignIn signIn)
		{
			if (!ModelState.IsValid)
			{
				return View(signIn);
			}
			User user = Service.GetUser(signIn.Name, signIn.Password);
			if (user == null)
			{
				ModelState.AddModelError(string.Empty, ErrorMessages.InvalidUsernameOrPassword);
				return View(signIn);
			}
			FormsAuthentication.SetAuthCookie(signIn.Name, true);

			// todo: use returnUrl
			return RedirectToAction("Index", "Home");
		}

		[Authorize]
		public ActionResult SignOut()
		{
			FormsAuthentication.SignOut();
			// todo: stay on the same page
			return RedirectToAction("Index", "Home");
		}
	}
}