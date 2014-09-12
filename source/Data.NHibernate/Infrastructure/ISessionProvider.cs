using NHibernate;

namespace Data.NHibernate.Infrastructure
{
    public interface ISessionProvider
    {
        ISession Open();
        void Close();
    }
}