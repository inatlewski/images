using AutoMapper;
using Images.Model.Mappings;
using Xunit;

namespace Images.Tests
{
    /// <summary>
    /// Unit tests of model mapping.
    /// Implements the <see cref="Images.Tests.BaseTest" />
    /// </summary>
    /// <seealso cref="Images.Tests.BaseTest" />
    public class MappingTest : BaseTest
    {
        [Fact]
        public void AssertConfigurationIsValid_ShouldNotThrowException()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
