using AutoMapper;
using Images.Model.Mappings;

namespace Images.Tests
{
    public class InitializeAutomapper
    {
        public InitializeAutomapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(ImageMappingProfile)));
        }
    }
}
