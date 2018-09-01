using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Images.Model.Mappings;
using Xunit;

namespace Images.Tests
{
    /// <summary>
    /// Base class for unit tests.
    /// Implements the <see cref="Xunit.IClassFixture{Images.Tests.InitializeAutomapper}" />
    /// </summary>
    /// <seealso cref="Xunit.IClassFixture{Images.Tests.InitializeAutomapper}" />
    public class BaseTest : IClassFixture<InitializeAutomapper>
    {
    }
}
