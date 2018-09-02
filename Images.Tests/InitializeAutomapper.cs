using AutoMapper;
using Images.Model.Mappings;

namespace Images.Tests
{
    /// <summary>
    /// Represents a class which initializes Automapper in unit tests.
    /// </summary>
    public class InitializeAutomapper
    {
        private static readonly object IsInitialized = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="InitializeAutomapper"/> class.
        /// </summary>
        static InitializeAutomapper()
        {
            if ((bool)IsInitialized)
            {
                return;
            }

            lock (IsInitialized)
            {
                if (!(bool)IsInitialized)
                {
                    Mapper.Initialize(cfg => cfg.AddProfiles(typeof(ImageMappingProfile)));
                    IsInitialized = true;
                }
            }
        }
    }
}
