using System;
using System.Net;
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

        public OperationResult<ImageOutDto> GetImage(int imageId)
        {
            try
            {
                var image = _imageRepository.FindByKey(imageId);

                if (image == null)
                {
                    return new OperationResult<ImageOutDto>(HttpStatusCode.NotFound, ErrorMessage.ImageNotFound);
                }

                var imageDto = Mapper.Map<ImageOutDto>(image);

                return new OperationResult<ImageOutDto>(imageDto, HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessage.GetImageException);

                return new OperationResult<ImageOutDto>(HttpStatusCode.InternalServerError, ErrorMessage.GetImageException);
            }
        }

        public OperationResult<ImageOutDto> AddImage(ImageInDto imageDto)
        {
            try
            {
                if (imageDto == null)
                {
                    return new OperationResult<ImageOutDto>(HttpStatusCode.BadRequest, ErrorMessage.ImageIsNull);
                }

                var imageToAdd = Mapper.Map<Image>(imageDto);
                var addedImage = _imageRepository.Add(imageToAdd);
                var imageOutDto = Mapper.Map<ImageOutDto>(addedImage);

                return new OperationResult<ImageOutDto>(imageOutDto, HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessage.AddImageException);

                return new OperationResult<ImageOutDto>(HttpStatusCode.InternalServerError, ErrorMessage.AddImageException);
            }
        }

        public OperationResult<ImageOutDto> UpdateImage(UpdateImageInDto imageDto)
        {
            try
            {
                if (imageDto == null)
                {
                    return new OperationResult<ImageOutDto>(HttpStatusCode.BadRequest, ErrorMessage.ImageIsNull);
                }

                var image = _imageRepository.FindByKey(imageDto.Id);

                if (image == null)
                {
                    return new OperationResult<ImageOutDto>(HttpStatusCode.NotFound, ErrorMessage.ImageNotFound);
                }

                Mapper.Map(imageDto, image);
                var updatedImage = _imageRepository.Update(image);
                var imageOutDto = Mapper.Map<ImageOutDto>(updatedImage);

                return new OperationResult<ImageOutDto>(imageOutDto, HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessage.UpdateImageException);

                return new OperationResult<ImageOutDto>(HttpStatusCode.InternalServerError, ErrorMessage.UpdateImageException);
            }
        }

        public OperationResult<bool> DeleteImage(int imageId)
        {
            try
            {
                var image = _imageRepository.FindByKey(imageId);

                if (image == null)
                {
                    return new OperationResult<bool>(HttpStatusCode.NotFound, ErrorMessage.ImageNotFound);
                }

                _imageRepository.Delete(image);

                return new OperationResult<bool>(true, HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _logger.Error(e, ErrorMessage.DeleteImageException);

                return new OperationResult<bool>(HttpStatusCode.InternalServerError, ErrorMessage.DeleteImageException);
            }
        }
    }
}
