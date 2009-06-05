using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using SikhResearchInstitute.Core.Domain;
using SikhResearchInstitute.Core.Domain.Model;
using Tarantino.Infrastructure.Commons.DataAccess.ORMapper;

namespace SikhResearchInstitute.Infrastructure.DataAccess.Impl
{
	public class UserRepository : KeyedRepository<User>, IUserRepository
	{
		public UserRepository(ISessionBuilder sessionFactory) : base(sessionFactory)
		{
		}

		public User GetByUserName(string username)
		{
			ISession session = GetSession();
			IQuery query = session.CreateQuery("from User u where u.Username = :username");
			query.SetString("username", username);

			var matchingUser = query.UniqueResult<User>();

			return matchingUser;
		}

		protected override string GetEntityNaturalKeyName()
		{
			return "Username";
		}
	}
}