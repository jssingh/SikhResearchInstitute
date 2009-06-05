using SikhResearchInstitute.Core.Domain.Model;

namespace SikhResearchInstitute.Core.Services
{
	public interface IUserSession
	{
		User GetCurrentUser();
		void LogIn(User user);
		void LogOut();
	}
}