using System;
using System.Linq;
using NHibernate;
using NUnit.Framework;
using SikhResearchInstitute.Core.Domain.Model;
using Tarantino.Core.Commons.Model;
using Tarantino.Infrastructure.Commons.DataAccess.ORMapper;
using Tarantino.Infrastructure.Commons.DataAccess.Repositories;

namespace SikhResearchInstitute.IntegrationTests.Infrastructure.DataAccess
{
    [TestFixture]
    public abstract class DataTestBase : RepositoryBase
    {
        protected DataTestBase(ISessionBuilder sessionFactory) : base(sessionFactory) { }
        protected DataTestBase() : base(new HybridSessionBuilder()) { }

        [SetUp]
        public void Setup()
        {
            DeleteAllObjects();
        }

        protected virtual void DeleteAllObjects()
        {
            var types = typeof(User).Assembly.GetTypes().Where(
                    type => type.BaseType == typeof(KeyedObject) || type.BaseType == typeof(PersistentObject) && !type.IsAbstract).ToArray();
            using (ISession session = GetSession())
            {
                foreach (Type type in types)
                {
                    session.Delete("from " + type.Name + " o");
                }
                session.Flush();
            }
        }

        protected void PersistEntities(params PersistentObject[] entities)
        {
            using (ISession session = GetSession())
            {
                foreach (PersistentObject entity in entities)
                {
                    session.SaveOrUpdate(entity);
                }
                session.Flush();
            }
        }

        protected void PersistEntity(PersistentObject entity)
        {
            using (ISession session = GetSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        protected static ISessionBuilder GetSessionBuilder()
        {
            return new HybridSessionBuilder();
        }
    }
}
