using Images.Common;
using Images.Model.DTO.In;
using Images.Model.DTO.Out;

namespace Images.BusinessLogic.Interfaces
{
    public interface IImageService
    {
        OperationResult<ImageOutDto> GetImage(int imageId);

        OperationResult<ImageOutDto> AddImage(ImageInDto imageDto);

        OperationResult<ImageOutDto> UpdateImage(UpdateImageInDto imageDto);

        OperationResult<bool> DeleteImage(int imageId);
    }
}