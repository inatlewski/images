using AutoMapper;
using Images.Model.Mappings;

namespace Images.Tests
{
    /// <summary>
    /// Represents a class which initializes Automapper in unit tests.
    /// </summary>
    public class InitializeAutomapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InitializeAutomapper"/> class.
        /// </summary>
        public InitializeAutomapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(ImageMappingProfile)));
        }
    }
}
