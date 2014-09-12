using Data.EntityFramework.Infrastructure;

namespace Tests.Data.EntityFramework.Infrastructure
{
    public class TestDatabaseContext : DatabaseContext
    {
        public TestDatabaseContext()
            : base("ForTestsEntityFrameworkConnection")
        {}
    }
}