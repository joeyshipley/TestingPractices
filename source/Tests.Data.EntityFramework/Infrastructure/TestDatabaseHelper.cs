using System.Data.Entity;

namespace Tests.Data.EntityFramework.Infrastructure
{
    public class TestDatabaseHelper
    {
        private readonly DbContext context;

        public TestDatabaseHelper(TestDatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public void CleanUp()
        {
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Conversations]");
        }
    }
}