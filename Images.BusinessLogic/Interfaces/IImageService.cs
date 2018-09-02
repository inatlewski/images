using Images.Model.DTO.In;
using Images.Model.DTO.Out;

namespace Images.BusinessLogic.Interfaces
{
    public interface IImageService
    {
        ImageOutDto GetImage(int imageId);

        bool AddImage(ImageInDto imageDto);

        bool UpdateImage(UpdateImageInDto imageDto);

        bool DeleteImage(int imageId);
    }
}