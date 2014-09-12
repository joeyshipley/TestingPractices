using System;
using NHibernate;

namespace Data.NHibernate.Infrastructure
{
    public class SessionWorker : ISessionWorker
    {
        private readonly ISessionProvider _sessionProvider;

        public SessionWorker(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public T Perform<T>(Func<ISession, T> act)
        {
            T result;
            using (var session = _sessionProvider.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = act(session);
                    transaction.Commit();
                }
            }
            return result;
        }

        public void Perform(Action<ISession> act)
        {
            using (var session = _sessionProvider.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    act(session);
                    transaction.Commit();
                }
            }
        }
    }
}