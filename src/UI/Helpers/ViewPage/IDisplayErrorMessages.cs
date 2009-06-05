using System.Web.Mvc;

namespace SikhResearchInstitute.UI.Helpers.ViewPage
{
	public interface IDisplayErrorMessages
	{
		string Display();
		ModelStateDictionary ModelState { set; }
		TempDataDictionary TempData { set; }
	}
}