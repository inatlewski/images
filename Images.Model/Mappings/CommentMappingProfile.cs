using AutoMapper;
using Images.Model.DTO.In;
using Images.Model.DTO.Out;
using Images.Model.Entities;

namespace Images.Model.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentOutDto>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Content, opts => opts.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedBy, opts => opts.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedDate, opts => opts.MapFrom(src => src.CreatedDate))
                .ForAllOtherMembers(opts => opts.Ignore());

            CreateMap<CommentInDto, Comment>()
                .ForMember(dest => dest.Content, opts => opts.MapFrom(src => src.Content))
                .ForMember(dest => dest.CreatedBy, opts => opts.MapFrom(src => src.CreatedBy))
                .ForAllOtherMembers(opts => opts.Ignore());
        }
    }
}
