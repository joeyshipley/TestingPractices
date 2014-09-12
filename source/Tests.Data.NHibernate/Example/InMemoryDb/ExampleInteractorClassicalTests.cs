using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Application.Example;
using Application.Example.Communication;
using Application.Example.Contract;
using Data.NHibernate.Infrastructure;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using Tests.Data.NHibernate.Infrastructure;

namespace Tests.Data.NHibernate.Example.ExampleInteractorTests.Classical.InMemoryDb
{
    [TestClass]
    public class When_Speak_WhenInvalid_SourceUnknown
        : ClassicalTest<ExampleInteractor>
    {
        private IExampleInteractor _exampleInteractor;
        private SpeakResult _result;

        public override void Arrange()
        {
            AssignFakes(new List<Action<ConfigurationExpression>>
            {
                (x => x.For<ISessionProvider>().Use<InMemorySessionProvider>())
            });
            _exampleInteractor = SystemUnderTest;
        }

        public override void Act()
        {
            var request = new SpeakRequest
            {
                Message = "Hello Test."
            };
            _result = _exampleInteractor.Speak(request);
        }

        [TestMethod]
        public void It_does_returns_invalid_error_message()
        {
            _result.Errors.Any(e => e.Key == "InvalidData")
                .Should().BeTrue();
        }

        [TestMethod]
        public void It_only_returns_one_error()
        {
            _result.Errors.Count(e => e.Key == "InvalidData")
                .Should().Be(1);
        }

        [TestMethod]
        public void It_returns_unsucessful_flag()
        {
            _result.WasSuccessful
                .Should().BeFalse();
        }

        [TestMethod]
        public void It_returns_an_unknown_conversation()
        {
            _result.Conversation.IsUnknown
                .Should().BeTrue();
        }
    }

    [TestClass]
    public class When_Speak_WhenInvalid_MessageMissing
        : ClassicalTest<ExampleInteractor>
    {
        private IExampleInteractor _exampleInteractor;
        private SpeakResult _result;

        public override void Arrange()
        {
            AssignFakes(new List<Action<ConfigurationExpression>>
            {
                (x => x.For<ISessionProvider>().Use<InMemorySessionProvider>())
            });

            _exampleInteractor = SystemUnderTest;
        }

        public override void Act()
        {
            var request = new SpeakRequest
            {
                Source = Rules.Being.Lion
            };
            _result = _exampleInteractor.Speak(request);
        }
        
        [TestMethod]
        public void It_does_returns_invalid_error_message()
        {
            _result.Errors.Any(e => e.Key == "InvalidData")
                .Should().BeTrue();
        }

        [TestMethod]
        public void It_only_returns_one_error()
        {
            _result.Errors.Count(e => e.Key == "InvalidData")
                .Should().Be(1);
        }

        [TestMethod]
        public void It_returns_unsucessful_flag()
        {
            _result.WasSuccessful
                .Should().BeFalse();
        }

        [TestMethod]
        public void It_returns_an_unknown_conversation()
        {
            _result.Conversation.IsUnknown
                .Should().BeTrue();
        }
    }

    [TestClass]
    public class When_Speak_WhenInvalid_MessageBadLength
        : ClassicalTest<ExampleInteractor>
    {
        private IExampleInteractor _exampleInteractor;
        private SpeakResult _result;

        public override void Arrange()
        {
            AssignFakes(new List<Action<ConfigurationExpression>>
            {
                (x => x.For<ISessionProvider>().Use<InMemorySessionProvider>())
            });

            _exampleInteractor = SystemUnderTest;
        }

        public override void Act()
        {
            var request = new SpeakRequest
            {
                Source = Rules.Being.Lion,
                Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus tempor libero eu sem tincidunt, quis interdum lectus hendrerit. Duis egestas neque nec mauris tristique, in consectetur dui varius. Sed faucibus urna et purus cursus, non ultricies augue pellentesque. Nullam lorem felis, ornare pretium sem pharetra, interdum bibendum mi. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Donec laoreet nunc ut augue commodo faucibus. In mi eros, scelerisque malesuada blandit quis, aliquet eu leo. Sed mattis neque ac dolor tincidunt semper. Vivamus urna turpis, ornare eget mi nec, volutpat maximus leo. Suspendisse potenti. Nulla facilisi."
            };
            _result = _exampleInteractor.Speak(request);
        }
        
        [TestMethod]
        public void It_does_returns_invalid_error_message()
        {
            _result.Errors.Any(e => e.Key == "InvalidData")
                .Should().BeTrue();
        }

        [TestMethod]
        public void It_only_returns_one_error()
        {
            _result.Errors.Count(e => e.Key == "InvalidData")
                .Should().Be(1);
        }

        [TestMethod]
        public void It_returns_unsucessful_flag()
        {
            _result.WasSuccessful
                .Should().BeFalse();
        }

        [TestMethod]
        public void It_returns_an_unknown_conversation()
        {
            _result.Conversation.IsUnknown
                .Should().BeTrue();
        }
    }
    
    [TestClass]
    public class When_Speak_AndAllIsWell
        : ClassicalTest<ExampleInteractor>
    {
        private IExampleInteractor _exampleInteractor;
        private SpeakResult _result;

        public override void Arrange()
        {
            AssignFakes(new List<Action<ConfigurationExpression>>
            {
                (x => x.For<ISessionProvider>().Use<InMemorySessionProvider>())
            });

            _exampleInteractor = SystemUnderTest;
        }

        public override void Act()
        {
            var request = new SpeakRequest
            {
                Source = Rules.Being.Lion,
                Message = "Lorem ipsum dolor sit amet."
            };
            _result = _exampleInteractor.Speak(request);
        }
        
        [TestMethod]
        public void It_does_not_return_errors()
        {
            _result.Errors.Any()
                .Should().BeFalse();
        }

        [TestMethod]
        public void It_returns_sucessful_flag()
        {
            _result.WasSuccessful
                .Should().BeTrue();
        }

        [TestMethod]
        public void It_does_not_return_an_unknown_conversation()
        {
            _result.Conversation.IsUnknown
                .Should().BeFalse();
        }

        [TestMethod]
        public void It_returns_the_new_conversation()
        {
            _result.Conversation.Id
                .Should().NotBe(Guid.Empty);
        }
    }
}