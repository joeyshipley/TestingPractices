using System;
using System.Linq;
using Application.Example;
using Application.Example.Communication;
using Application.Example.Contract;
using Domain;
using Domain.Example.Entity;
using FluentAssertions;
using Tests.Data.EntityFramework.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.EntityFramework.Application.Example.ExampleInteractorTests.Classical.TestDb
{
    [TestClass]
    public class When_Speak_WhenInvalid_SourceUnknown
        : ClassicalTest<ExampleInteractor>
    {
        private IExampleInteractor _exampleInteractor;
        private SpeakResult _result;

        public override void Arrange()
        {
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
            var validConversation = new Conversation
            {
                Source = Rules.Being.Lion,
                Message = "Lorem ipsum dolor sit amet."
            };
            var addedConversation = validConversation;
            addedConversation.Id = Guid.NewGuid();

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