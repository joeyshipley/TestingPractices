using Data.EntityFramework.Infrastructure;
using Infrastructure.IoC.Unity;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.EntityFramework.Infrastructure
{
    public class ClassicalTest<T>
        where T : class
    {
        protected T SystemUnderTest;
        private TestDatabaseHelper databaseHelper;
        
        [TestInitialize]
        public virtual void Init()
        {
            var container = Configuration.GetContainer();
            container.RegisterType(typeof(IDatabaseContext), typeof(TestDatabaseContext));
            var testDbContext = container.Resolve<TestDatabaseContext>();
            databaseHelper = new TestDatabaseHelper(testDbContext);

            SystemUnderTest = container.Resolve<T>();

            Arrange();
            Act();
        }

        [TestCleanup]
        public virtual void TestCleanup() 
        {
            CleanUp();
            databaseHelper.CleanUp();
        }

        public virtual void Arrange() {}
        public virtual void Act() {}
        public virtual void CleanUp() {}
    }
}