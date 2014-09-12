using AutoMoq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.EntityFramework.Infrastructure
{
    public class MockistTest<T>
        where T : class
    {
        protected AutoMoqer Mocker;
        protected T SystemUnderTest;
        
        [TestInitialize]
        public virtual void Init()
        {
            Mocker = new AutoMoqer();
            SystemUnderTest = Mocker.Resolve<T>();

            Arrange();
            Act();
        }

        [TestCleanup]
        public virtual void TestCleanup() 
        {
            CleanUp();
        }

        public virtual void Arrange() {}
        public virtual void Act() {}
        public virtual void CleanUp() {}
    }
}