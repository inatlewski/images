using System;
using Images.BusinessLogic.Interfaces;
using Images.DataAccess.Interfaces;
using Images.Model.DTO.In;
using Images.Model.DTO.Out;
using Images.Model.Entities;

namespace Images.BusinessLogic.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> _imageRepository;

        public ImageService(IRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public ImageOutDto GetImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public bool AddImage(ImageInDto imageDto)
        {
            throw new NotImplementedException();
        }

        public bool UpdateImage(UpdateImageInDto imageDto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteImage(int imageId)
        {
            throw new NotImplementedException();
        }
    }
}
