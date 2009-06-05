using System;
using System.Web.Mvc;
using SikhResearchInstitute.Core.Domain;
using SikhResearchInstitute.Core.Domain.Model;
using SikhResearchInstitute.Core.Services;
using SikhResearchInstitute.UI.Helpers.Filters;
using SikhResearchInstitute.UI.Models.Forms;

namespace SikhResearchInstitute.UI.Controllers
{
	public class LoginController : SmartController
	{
		private readonly IAuthenticationService _authenticationService;
		private readonly IUserRepository _repository;
		private readonly IUserSession _userSession;

		public LoginController(IAuthenticationService authenticationService, IUserRepository repository,
		                       IUserSession userSession)
		{
			_authenticationService = authenticationService;
			_repository = repository;
			_userSession = userSession;
		}

		public ViewResult Index()
		{
			return View(new LoginForm());
		}

		[ValidateModel(typeof (LoginForm))]
		public ViewResult Login([Bind(Prefix = "")] LoginForm form)
		{
			if (!ModelState.IsValid)
			{
				return View("index", form);
			}

			User user = _repository.GetByUserName(form.Username);
			if (user != null)
			{
				bool passwordMatches = _authenticationService.PasswordMatches(user, form.Password);

				if (passwordMatches)
				{
					_userSession.LogIn(user);
					return View("index", form);
				}
			}

			ModelState.AddModelError("Login", "Login incorrect");
			return View("index", form);
		}

		public ActionResult LogOut()
		{
			_userSession.LogOut();
			throw new InvalidOperationException("If the previous line doesn't redirect, we have a problem.");
		}
	}
}