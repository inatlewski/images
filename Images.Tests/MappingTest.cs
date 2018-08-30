using AutoMapper;
using Images.Model.Mappings;
using Xunit;

namespace Images.Tests
{
    public class MappingTest : BaseTest
    {
        [Fact]
        public void AssertConfigurationIsValid_ShouldNotThrowException()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
