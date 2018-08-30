using AutoMapper;
using Images.Model.DTO.In;
using Images.Model.DTO.Out;
using Images.Model.Entities;

namespace Images.Model.Mappings
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<Image, ImageOutDto>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Url, opts => opts.MapFrom(src => src.Url))
                .ForMember(dest => dest.CreatedBy, opts => opts.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedDate, opts => opts.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.Comments, opts => opts.MapFrom(src => src.Comments))
                .ForAllOtherMembers(opts => opts.Ignore());

            CreateMap<ImageInDto, Image>()
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedBy, opts => opts.MapFrom(src => src.CreatedBy))
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
