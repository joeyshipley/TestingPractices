using System.Data.Entity;
using Domain.Example.Entity;

namespace Data.EntityFramework.Infrastructure
{
    public abstract class DatabaseContext : DbContext, IDatabaseContext
    {
        protected DatabaseContext(string connectionStringKey)
            : base(connectionStringKey)
        {}

        public virtual DbSet<Conversation> Conversations { get; set; }

        public void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        } 
    }
}