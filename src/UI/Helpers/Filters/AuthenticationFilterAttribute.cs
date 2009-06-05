using System.Web.Mvc;
using MvcContrib;
using SikhResearchInstitute.Core.Domain.Model;
using SikhResearchInstitute.Core.Services;
using SikhResearchInstitute.DependencyResolution;

namespace SikhResearchInstitute.UI.Helpers.Filters
{
	public class AuthenticationFilterAttribute : ActionFilterAttribute
	{
		private readonly IUserSession _session;

		public AuthenticationFilterAttribute(IUserSession session)
		{
			_session = session;
		}

		public AuthenticationFilterAttribute()
			: this(DependencyRegistrar.Resolve<IUserSession>()) {}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			ControllerBase controller = filterContext.Controller;
			User user = _session.GetCurrentUser();
			if (user != null)
			{
				controller.ViewData.Add(user);
			}
		}
	}
}