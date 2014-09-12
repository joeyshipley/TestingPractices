using Application.DomainAdapter;
using Application.DomainAdapter.Contract;
using Application.Example.Communication;
using Domain;
using Domain.Example.Communication;
using FluentAssertions;
using Tests.Data.EntityFramework.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.EntityFramework.Application.DomainAdapter.RequestMapperTests.Classical.TestDb
{
    [TestClass]
    public class When_RequestMapping_AndAllIsWell
        : ClassicalTest<RequestMapper>
    {
        private IRequestMapper _requestMapper;
        private CreateSpeakRequest _result;

        public override void Arrange()
        {
            _requestMapper = SystemUnderTest;
        }

        public override void Act()
        {
            var request = new SpeakRequest
            {
                Source = Rules.Being.Lion,
                Message = "Hello Test."
            };
            _result = _requestMapper.MapFrom(request);
        }
        
        [TestMethod]
        public void It_maps_the_Source()
        {
            _result.Source
                .Should().Be(Rules.Being.Lion);
        }
        
        [TestMethod]
        public void It_maps_the_Message()
        {
            _result.Message
                .Should().Be("Hello Test.");
        }
    }
}