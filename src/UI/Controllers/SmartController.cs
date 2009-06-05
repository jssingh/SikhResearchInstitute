using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib;
using SikhResearchInstitute.UI.Helpers.Extensions;
using SikhResearchInstitute.UI.Helpers.Filters;
using SikhResearchInstitute.UI.Models;

namespace SikhResearchInstitute.UI.Controllers
{
	public abstract class SmartController : Controller
	{
	    protected ViewResult NotAuthorizedView
	    {
	        get
	        {
	            return View(ViewPages.NotAuthorized);
	        }
	    }
		protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
		    if (!ViewData.Contains<PageInfo>())
            {
                PageInfo pageInfo = new PageInfo {Title = "Sikh Research Institute"};
                ViewData.Add(pageInfo);
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			//temporarily putting it here.
			var authentication = new AuthenticationFilterAttribute();
			authentication.OnActionExecuting(filterContext);
        }

		public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression)
		{
			string controllerName = typeof (TController).GetControllerName();
			string actionName = actionExpression.GetActionName();

			return RedirectToAction(actionName, controllerName);
		}

		public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
		                                                           IDictionary<string, object> dictionary)
		{
			string controllerName = typeof (TController).GetControllerName();
			string actionName = actionExpression.GetActionName();

			return RedirectToAction(actionName, controllerName,
			                        new RouteValueDictionary(dictionary));
		}

		public RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression,
		                                                           object values)
		{
			string controllerName = typeof (TController).GetControllerName();
			string actionName = actionExpression.GetActionName();

			return RedirectToAction(actionName, controllerName,
			                        new RouteValueDictionary(values));
		}
	}
}