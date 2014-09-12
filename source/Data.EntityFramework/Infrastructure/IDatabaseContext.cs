using System.Data.Entity;
using Domain.Example.Entity;

namespace Data.EntityFramework.Infrastructure
{
    public interface IDatabaseContext
    {
        DbSet<Conversation> Conversations { get; set; }
        void Commit();
    }
}