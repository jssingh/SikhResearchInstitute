using SikhResearchInstitute.Core.Domain.Model;

namespace SikhResearchInstitute.Core.Services
{
	public interface IAuthenticationService
	{
		bool PasswordMatches(User user, string password);
	}
}