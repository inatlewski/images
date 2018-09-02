using System;
using Images.Model.DTO.In;
using Images.Model.Entities;

namespace Images.BusinessLogic.Interfaces
{
    public interface IImageService
    {
        Image GetImage(int imageId);

        bool AddImage(ImageInDto imageDto);

        bool UpdateImage(UpdateImageInDto imageDto);

        bool DeleteImage(int imageId);
    }
}