using System;
using System.Collections.Generic;
using Infrastructure.IoC.Structuremap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace Tests.Data.NHibernate.Infrastructure
{
    public class ClassicalTest<T>
        where T : class
    {
        protected T SystemUnderTest;
        protected IContainer Container;
        
        [TestInitialize]
        public virtual void Init()
        {
            populateSystemUnderTest();

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

        protected void AssignFakes(List<Action<ConfigurationExpression>> fakes)
        {
            populateSystemUnderTest(fakes);
        }
        
        private void populateSystemUnderTest()
        {
            populateSystemUnderTest(new List<Action<ConfigurationExpression>>());
        }

        private void populateSystemUnderTest(List<Action<ConfigurationExpression>> fakes)
        {
            Container = Configuration.BuildContainer(fakes);
            SystemUnderTest = Container.GetInstance<T>();
        }
    }
}