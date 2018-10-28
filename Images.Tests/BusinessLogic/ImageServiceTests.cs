using System;
using System.Net;
using FluentAssertions;
using Images.BusinessLogic.Implementations;
using Images.BusinessLogic.Interfaces;
using Images.Common;
using Images.DataAccess.Interfaces;
using Images.Model.DTO.In;
using Images.Model.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Serilog;
using Xunit;

namespace Images.Tests.BusinessLogic
{
    public class ImageServiceTests : BaseTest
    {
        private readonly IImageService _imageService;
        private readonly IRepository<Image> _imageRepository;
        private readonly ILogger _logger;

        public ImageServiceTests()
        {
            _imageRepository = Substitute.For<IRepository<Image>>();
            _logger = Substitute.For<ILogger>();
            _imageService= new ImageService(_imageRepository, _logger);
        }

        #region GetImage
        [Fact]
        public void GetImage_ShouldReturnImageFromRepositoryWithOkStatus_WhenImageExists()
        {
            // Arrange
            var imageId = 1;
            var image = new Image
            {
                Id = imageId
            };
            _imageRepository.FindByKey(imageId).Returns(image);

            // Act
            var result = _imageService.GetImage(imageId);

            //Assert
            result.Model.Id.Should().Be(imageId);
            result.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeEmpty();
            _imageRepository.Received().FindByKey(imageId);
        }

        [Fact]
        public void GetImage_ShouldReturnNullWithNotFoundStatus_WhenImageDoesNotExist()
        {
            // Arrange
            var imageId = 1;
            _imageRepository.FindByKey(imageId).ReturnsNull();

            // Act
            var result = _imageService.GetImage(imageId);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Errors.Should().Contain(ErrorMessage.ImageNotFound);
            _imageRepository.Received().FindByKey(imageId);
        }

        [Fact]
        public void GetImage_ShouldLogExceptionAndReturnNullWithInternalServerErrorStatus_WhenExceptionWasThrown()
        {
            // Arrange
            var imageId = 1;
            var exception = new Exception();
            _imageRepository.When(r => r.FindByKey(imageId)).Do(x => throw exception);

            // Act
            var result = _imageService.GetImage(imageId);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Errors.Should().Contain(ErrorMessage.GetImageException);
            _logger.Received().Error(exception, ErrorMessage.GetImageException);
        }
        #endregion

        #region AddImage
        [Fact]
        public void AddImage_ShouldAddImageToRepositoryAndReturnImageWithCreatedStatus_WhenModelIsNotNull()
        {
            // Arrange
            var imageDto = new ImageInDto();
            var newImageId = 1;
            _imageRepository.Add(Arg.Any<Image>()).Returns(call =>
            {
                var image = call.Arg<Image>();
                image.Id = newImageId;
                return image;
            });

            // Act
            var result = _imageService.AddImage(imageDto);

            //Assert
            result.Model.Id.Should().Be(newImageId);
            result.HttpStatusCode.Should().Be(HttpStatusCode.Created);
            result.Errors.Should().BeEmpty();
            _imageRepository.Received(1).Add(Arg.Any<Image>());
        }

        [Fact]
        public void AddImage_ShouldReturnNullWithBadRequestStatus_WhenModelIsNull()
        {
            // Arrange
            ImageInDto imageDto = null;

            // Act
            var result = _imageService.AddImage(imageDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.Errors.Should().Contain(ErrorMessage.ImageIsNull);
            _imageRepository.DidNotReceive().Update(Arg.Any<Image>());
        }

        [Fact]
        public void AddImage_ShouldLogExceptionAndReturnNullWithInternalServerErrorStatus_WhenExceptionWasThrown()
        {
            // Arrange
            var imageDto = new ImageInDto();
            var exception = new Exception();
            _imageRepository.When(r => r.Add(Arg.Any<Image>())).Do(x => throw exception);

            // Act
            var result = _imageService.AddImage(imageDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Errors.Should().Contain(ErrorMessage.AddImageException);
            
            
            _logger.Received().Error(exception, ErrorMessage.AddImageException);
        }
        #endregion

        #region UpdateImage
        [Fact]
        public void UpdateImage_ShouldUpdateImageInRepositoryAndReturnImageWithOkStatus_WhenImageExists()
        {
            // Arrange
            var imageId = 1;
            var imageDto = new UpdateImageInDto
            {
                Id = imageId
            };
            var image = new Image
            {
                Id = imageId
            };
            _imageRepository.FindByKey(imageDto.Id).Returns(image);
            _imageRepository.Update(Arg.Any<Image>()).Returns(call => call.Arg<Image>());

            // Act
            var result = _imageService.UpdateImage(imageDto);

            //Assert
            result.Model.Id.Should().Be(imageId);
            result.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeEmpty();
            _imageRepository.Received(1).Update(image);
        }

        [Fact]
        public void UpdateImage_ShouldNotUpdateAnyImageInRepositoryAndReturnNullWithBadRequestStatus_WhenModelIsNull()
        {
            // Arrange
            UpdateImageInDto imageDto = null;

            // Act
            var result = _imageService.UpdateImage(imageDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            result.Errors.Should().Contain(ErrorMessage.ImageIsNull);
            _imageRepository.DidNotReceive().Update(Arg.Any<Image>());
        }

        [Fact]
        public void UpdateImage_ShouldNotUpdateAnyImageInRepositoryAndReturnNullWithNotFoundStatus_WhenImageDoesNotExist()
        {
            // Arrange
            var imageDto = new UpdateImageInDto
            {
                Id = 1
            };
            _imageRepository.FindByKey(imageDto.Id).ReturnsNull();

            // Act
            var result = _imageService.UpdateImage(imageDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Errors.Should().Contain(ErrorMessage.ImageNotFound);
            _imageRepository.Received(1).FindByKey(imageDto.Id);
            _imageRepository.DidNotReceive().Update(Arg.Any<Image>());
        }

        [Fact]
        public void UpdateImage_ShouldLogExceptionAndReturnNullWithInternalServerErrorStatus_WhenExceptionWasThrown()
        {
            // Arrange
            var imageId = 1;
            var imageDto = new UpdateImageInDto
            {
                Id = imageId
            };
            var image = new Image();
            var exception = new Exception();
            _imageRepository.FindByKey(imageDto.Id).Returns(image);
            _imageRepository.When(r => r.Update(Arg.Any<Image>())).Do(x => throw exception);

            // Act
            var result = _imageService.UpdateImage(imageDto);

            //Assert
            result.Model.Should().BeNull();
            result.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Errors.Should().Contain(ErrorMessage.UpdateImageException);
            _logger.Received().Error(exception, ErrorMessage.UpdateImageException);
        }
        #endregion

        #region DeleteImage
        [Fact]
        public void DeleteImage_ShouldDeleteImageFromRepositoryAndReturnTrueWithOkStatus_WhenImageExists()
        {
            // Arrange
            var imageId = 1;
            var image = new Image();
            _imageRepository.FindByKey(imageId).Returns(image);

            // Act
            var result = _imageService.DeleteImage(imageId);

            //Assert
            result.Model.Should().BeTrue();
            result.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            result.Errors.Should().BeEmpty();
            _imageRepository.Received().FindByKey(imageId);
            _imageRepository.Received().Delete(image);
        }

        [Fact]
        public void DeleteImage_ShouldNotDeleteAnyImageFromRepositoryAndReturnFalseWithNotFoundStatus_WhenImageDoesNotExist()
        {
            // Arrange
            var imageId = 1;
            _imageRepository.FindByKey(imageId).ReturnsNull();

            // Act
            var result = _imageService.DeleteImage(imageId);

            //Assert
            result.Model.Should().BeFalse();
            result.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Errors.Should().Contain(ErrorMessage.ImageNotFound);
            _imageRepository.Received().FindByKey(imageId);
            _imageRepository.DidNotReceive().Delete(Arg.Any<Image>());
        }

        [Fact]
        public void DeleteImage_ShouldLogExceptionAndReturnFalseWithInternalServerErrorStatus_WhenExceptionWasThrown()
        {
            // Arrange
            var imageId = 1;
            var image = new Image();
            var exception = new Exception();
            _imageRepository.FindByKey(imageId).Returns(image);
            _imageRepository.When(r => r.Delete(Arg.Any<Image>())).Do(x => throw exception);

            // Act
            var result = _imageService.DeleteImage(imageId);

            //Assert
            result.Model.Should().BeFalse();
            result.HttpStatusCode.Should().Be(HttpStatusCode.InternalServerError);
            result.Errors.Should().Contain(ErrorMessage.DeleteImageException);
            _logger.Received().Error(exception, ErrorMessage.DeleteImageException);
        } 
        #endregion
    }
}