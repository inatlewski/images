using System;
using AutoMapper;
using Images.BusinessLogic.Interfaces;
using Images.Common;
using Images.DataAccess.Interfaces;
using Images.Model.DTO.In;
using Images.Model.DTO.Out;
using Images.Model.Entities;
using Serilog;

namespace Images.BusinessLogic.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> _imageRepository;
        private readonly ILogger _logger;

        public ImageService(IRepository<Image> imageRepository, ILogger logger)
        {
            _imageRepository = imageRepository;
            _logger = logger;
        }

        public ImageOutDto GetImage(int imageId)
        {
            try
            {
                var image = _imageRepository.FindByKey(imageId);

                if (image == null)
                {
                    return null;
                }

                var imageDto = Mapper.Map<ImageOutDto>(image);

                return imageDto;
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.GetImageExceptionMessage);

                return null;
            }
        }

        public bool AddImage(ImageInDto imageDto)
        {
            try
            {
                if (imageDto == null)
                {
                    return false;
                }

                var image = Mapper.Map<Image>(imageDto);
                _imageRepository.Add(image);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.AddImageExceptionMessage);

                return false;
            }
        }

        public bool UpdateImage(UpdateImageInDto imageDto)
        {
            try
            {
                if (imageDto == null)
                {
                    return false;
                }

                var image = _imageRepository.FindByKey(imageDto.Id);

                if (image == null)
                {
                    return false;
                }

                Mapper.Map(imageDto, image);
                _imageRepository.Update(image);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.UpdateImageExceptionMessage);

                return false;
            }
        }

        public bool DeleteImage(int imageId)
        {
            try
            {
                var image = _imageRepository.FindByKey(imageId);

                if (image == null)
                {
                    return false;
                }

                _imageRepository.Delete(image);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessages.DeleteImageExceptionMessage);

                return false;
            }
        }
    }
}
