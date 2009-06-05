using NHibernate;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using SikhResearchInstitute.Core.Domain.Model;
using SikhResearchInstitute.Infrastructure.DataAccess.Impl;

namespace SikhResearchInstitute.IntegrationTests.Infrastructure.DataAccess
{
    [TestFixture]
    public class UserRepositoryTester : RepositoryTester<User, UserRepository>
    {
        [Test]
        public void Should_find_user_by_username()
        {
            var one = new User
            {
                Username = "hsimpson",
            };

            var two = new User
            {
                Username = "bsimpson",
            };

            var three = new User
            {
                Username = "lsimpson",
            };

            using (ISession session = GetSession())
            {
                session.SaveOrUpdate(one);
                session.SaveOrUpdate(two);
                session.SaveOrUpdate(three);
                session.Flush();
            }

            var repository = CreateRepository();
            User employee = repository.GetByUserName("bsimpson");

            Assert.That(employee.Id, Is.EqualTo(two.Id));
            Assert.That(employee.Username, Is.EqualTo(two.Username));
        }

        protected override UserRepository CreateRepository()
        {
            return new UserRepository(GetSessionBuilder());
        }
    }
}
