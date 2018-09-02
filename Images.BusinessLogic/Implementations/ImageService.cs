using System;
using System.Collections.Generic;
using System.Text;
using Images.BusinessLogic.Interfaces;
using Images.DataAccess.Interfaces;
using Images.Model.DTO.In;
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

        public Image GetImage()
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
