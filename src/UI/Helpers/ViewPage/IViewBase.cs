using System.Web.Mvc;

namespace SikhResearchInstitute.UI.Helpers.ViewPage
{
	public interface IViewBase : IViewDataContainer
	{
		IDisplayErrorMessages Errors { get; }
		HtmlHelper Html { get; }
		UrlHelper Url { get; }
	}
}