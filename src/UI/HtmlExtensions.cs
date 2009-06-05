using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SikhResearchInstitute.UI.Helpers.Extensions;

namespace SikhResearchInstitute.UI
{
    public static class HtmlExtensions
    {
        public static string ActionLink<TController>(this HtmlHelper helper, string linkText,
                                                     Expression<Func<TController, object>> actionExpression)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();

            return helper.ActionLink(linkText, actionName, controllerName);
        }
    }
}