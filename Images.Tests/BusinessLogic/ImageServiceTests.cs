using FluentAssertions;
using Images.BusinessLogic.Implementations;
using Images.BusinessLogic.Interfaces;
using Images.DataAccess.Interfaces;
using Images.Model.DTO.In;
using Images.Model.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Images.Tests.BusinessLogic
{
    public class ImageServiceTests : BaseTest
    {
        private readonly IImageService _imageService;
        private readonly IRepository<Image> _imageRepository;

        public ImageServiceTests()
        {
            _imageRepository = Substitute.For<IRepository<Image>>();
            _imageService= new ImageService(_imageRepository); 
        }

        [Fact]
        public void GetImage_ShouldReturnImageFromRepository_WhenImageExists()
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
            result.Id.Should().Be(imageId);
            _imageRepository.Received().FindByKey(imageId);
        }

        [Fact]
        public void GetImage_ShouldReturnNull_WhenImageDoesNotExist()
        {
            // Arrange
            var imageId = 1;
            _imageRepository.FindByKey(imageId).ReturnsNull();

            // Act
            var result = _imageService.GetImage(imageId);

            //Assert
            result.Should().BeNull();
            _imageRepository.Received().FindByKey(imageId);
        }

        [Fact]
        public void AddImage_ShouldAddImageToRepositoryAndReturnTrue_WhenModelIsNotNull()
        {
            // Arrange
            var imageDto = new ImageInDto();

            // Act
            var result =_imageService.AddImage(imageDto);

            //Assert
            result.Should().BeTrue();
            _imageRepository.Received(1).Add(Arg.Any<Image>());
        }

        [Fact]
        public void AddImage_ShouldReturnFalse_WhenModelIsNull()
        {
            // Arrange
            ImageInDto imageDto = null;
            
            // Act
            var result = _imageService.AddImage(imageDto);

            //Assert
            result.Should().BeFalse();
            _imageRepository.DidNotReceive().Update(Arg.Any<Image>());
        }

        [Fact]
        public void UpdateImage_ShouldUpdateImageInRepositoryAndReturnTrue_WhenImageExists()
        {
            // Arrange
            var imageDto = new UpdateImageInDto
            {
                Id = 1
            };
            var image = new Image();
            _imageRepository.FindByKey(imageDto.Id).Returns(image);

            // Act
            var result = _imageService.UpdateImage(imageDto);

            //Assert
            result.Should().BeTrue();
            _imageRepository.Received(1).Update(image);
        }

        [Fact]
        public void UpdateImage_ShouldNotUpdateAnyImageInRepositoryAndReturnFalse_WhenModelIsNull()
        {
            // Arrange
            UpdateImageInDto imageDto = null;

            // Act
            var result = _imageService.UpdateImage(imageDto);

            //Assert
            result.Should().BeFalse();
            _imageRepository.DidNotReceive().Update(Arg.Any<Image>());
        }

        [Fact]
        public void UpdateImage_ShouldNotUpdateAnyImageInRepositoryAndReturnFalse_WhenImageDoesNotExist()
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
            result.Should().BeFalse();
            _imageRepository.Received(1).FindByKey();
            _imageRepository.DidNotReceive().Update(Arg.Any<Image>());
        }

        [Fact]
        public void DeleteImage_ShouldDeleteImageFromRepositoryAndReturnTrue_WhenImageExists()
        {
            // Arrange
            var imageId = 1;
            var image = new Image();
            _imageRepository.FindByKey(imageId).Returns(image);

            // Act
            var result = _imageService.DeleteImage(imageId);

            //Assert
            result.Should().BeTrue();
            _imageRepository.Received().FindByKey(imageId);
            _imageRepository.Received().Delete(image);
        }

        [Fact]
        public void DeleteImage_ShouldNotDeleteAnyImageFromRepositoryAndReturnFalse_WhenImageDoesNotExist()
        {
            // Arrange
            var imageId = 1;
            _imageRepository.FindByKey(imageId).ReturnsNull();

            // Act
            var result = _imageService.DeleteImage(imageId);

            //Assert
            result.Should().BeFalse();
            _imageRepository.Received().FindByKey(imageId);
            _imageRepository.DidNotReceive().Delete(Arg.Any<Image>());
        }
    }
}