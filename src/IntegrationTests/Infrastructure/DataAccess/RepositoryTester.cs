using NBehave.Spec.NUnit;
using NHibernate;
using NUnit.Framework;
using SikhResearchInstitute.Core.Domain;
using Tarantino.Core.Commons.Model;

namespace SikhResearchInstitute.IntegrationTests.Infrastructure.DataAccess
{
	public abstract class RepositoryTester<T, TRepository> : DataTestBase
		where T : PersistentObject, new()
		where TRepository : IRepository<T>
	{
		[Test]
		public virtual void Should_get_by_id()
		{
			var one = new T();
			var two = new T();
			var three = new T();
			PersistEntities(one, two, three);

			TRepository repository = CreateRepository();

			T returnedFromDatabase = repository.GetById(one.Id);
			returnedFromDatabase.ShouldEqual(one);
		}

		protected abstract TRepository CreateRepository();

		[Test]
		public virtual void Should_save_one()
		{
			var one = new T();
			TRepository repository = CreateRepository();
			repository.Save(one);

			GetSession().Dispose();

			using (ISession session = GetSession())
			{
				var reloaded = session.Load<T>(one.Id);
				reloaded.Id.ShouldEqual(one.Id);
			}
		}
	}
}