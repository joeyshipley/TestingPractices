using System.Data;
using Data.NHibernate.Infrastructure;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Tests.Data.NHibernate.Infrastructure
{
    public class InMemorySessionProvider : ISessionProvider
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;
        private IDbConnection _connection;

        public ISession Open()
        {
            if(_sessionFactory == null)
                _sessionFactory = configureSessionFactory();

            return _sessionFactory.OpenSession(_connection);
        }

        public void Close()
        {
            if(_sessionFactory != null)
                _sessionFactory.Dispose();
 
            _sessionFactory = null;
            _configuration = null;
        }

        private ISessionFactory configureSessionFactory()
        {
            var factory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SessionProvider>())
                .ExposeConfiguration(cfg => _configuration = cfg)
                .BuildSessionFactory();

            var session = factory.OpenSession();
            _connection = session.Connection;
            var export = new SchemaExport(_configuration);
            export.Execute(true, true, false, _connection, null);            

            return factory;
        }
    } 
}