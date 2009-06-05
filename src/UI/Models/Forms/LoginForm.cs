using Castle.Components.Validator;

namespace SikhResearchInstitute.UI.Models.Forms
{
	public class LoginForm
	{
		[ValidateNonEmpty]
		public string Username { get; set; }

		[ValidateNonEmpty]		
		public string Password { get; set; }
	}
}