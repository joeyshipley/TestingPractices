namespace Data.EntityFramework.Infrastructure
{
    public class EntityFrameworkContext : DatabaseContext
    {
        public EntityFrameworkContext()
            : base("EntityFrameworkConnection")
        {}
    }
}