using System.Collections.Generic;
using System.Web.Mvc;

namespace SikhResearchInstitute.UI.Helpers.Extensions
{
	public static class ModelStateExtensions
	{
		public static bool IsInvalid(this ModelStateDictionary state)
		{
			return !state.IsValid;
		}

		public static void AddModelErrors(this ModelStateDictionary state, IDictionary<string, string[]> bag)
		{
			foreach (string key in bag.Keys)
			{
				foreach (string value in bag[key])
				{
					state.AddModelError(key, value);
				}
			}
		}
	}
}