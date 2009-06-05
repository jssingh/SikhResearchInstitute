using NBehave.Spec.NUnit;
using NUnit.Framework;
using Rhino.Mocks;
using SikhResearchInstitute.Core.Domain.Model;
using SikhResearchInstitute.Core.Services;
using SikhResearchInstitute.Core.Services.Impl;

namespace SikhResearchInstitute.UnitTests.Core.Services
{
	[TestFixture]
	public class AuthenticationServiceTester : TestBase
	{
		[Test]
		public void Should_authenticate_if_salt_matches()
		{
			var user = new User {PasswordHash = "123xyz"};
			var cryptographer = S<ICryptographer>();
			cryptographer.Stub(x => x.GetPasswordHash("password", user.PasswordSalt)).Return("123xyz");
			cryptographer.Stub(x => x.GetPasswordHash("pasword", user.PasswordSalt)).Return("123xy");

			IAuthenticationService service = new AuthenticationService(cryptographer);

			service.PasswordMatches(user, "password").ShouldBeTrue();
			service.PasswordMatches(user, "pasword").ShouldBeFalse();
		}
	}
}