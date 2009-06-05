using System;
using NHibernate;
using SikhResearchInstitute.Core.Domain;
using Tarantino.Core.Commons.Model;
using Tarantino.Infrastructure.Commons.DataAccess.ORMapper;
using Tarantino.Infrastructure.Commons.DataAccess.Repositories;

namespace SikhResearchInstitute.Infrastructure.DataAccess.Impl
{
    public class RepositoryBase<T> : RepositoryBase, IRepository<T> where T : PersistentObject
    {
        public RepositoryBase(ISessionBuilder sessionFactory) : base(sessionFactory)
        {
        }

        public T GetById(Guid id)
        {
            ISession session = GetSession();
            return session.Get<T>(id);
        }

        public void Save(T entity)
        {
            using (ISession session = GetSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(entity);    
                transaction.Commit();
            }
        }
    }
}
