using Data.NHibernate.Infrastructure;
using StructureMap;

namespace Tests.Data.NHibernate.Infrastructure
{
    public static class TestDatabaseHelper
    {
        public static void CleanUpDb(IContainer container)
        {
            var sessionProvider = container.GetInstance<ISessionProvider>();
            using (var session = sessionProvider.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.CreateSQLQuery("DELETE FROM Conversations")
                        .ExecuteUpdate();

                    transaction.Commit();
                }
            }
        }
    }
}