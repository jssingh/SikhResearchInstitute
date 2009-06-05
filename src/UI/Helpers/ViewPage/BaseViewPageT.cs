using System.Web.Mvc;
using SikhResearchInstitute.DependencyResolution;

namespace SikhResearchInstitute.UI.Helpers.ViewPage
{
	public class BaseViewPage<TModel> : ViewPage<TModel>, IViewBase where TModel : class
	{
		protected readonly IDisplayErrorMessages _displayErrorMessages;

		public BaseViewPage()
		{
			_displayErrorMessages = DependencyRegistrar.Resolve<IDisplayErrorMessages>();
		}

		public IDisplayErrorMessages Errors
		{
			get
			{
				_displayErrorMessages.TempData = TempData;
				_displayErrorMessages.ModelState = ViewData.ModelState;
				return _displayErrorMessages;
			}
		}
	}
}